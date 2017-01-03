using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using QuizIt.Domain;

namespace DataAccess.Sql
{
    public class QuizSqlDataAccess : IQuizDataAccess, IDisposable
    {
        private string dbConnectionString;
        private SqlConnection dbConnection;
        private IDbCommand dbCommand;

        public QuizSqlDataAccess() => SetConnectionString();

        private void SetConnectionString()
        {
            if (ConfigurationManager.ConnectionStrings["DbCnnString"] == null)
                throw new InvalidOperationException("DbCnnString connection string is null");
            dbConnectionString = ConfigurationManager.ConnectionStrings["DbCnnString"].ConnectionString;
            if (string.IsNullOrEmpty(dbConnectionString))
                throw new InvalidOperationException($"{nameof(dbConnectionString)} is null");
            dbConnection = new SqlConnection(dbConnectionString);
        }

        /// <summary>
        /// Get a collection containing all the quizzes in the database.
        /// </summary>
        /// <returns>A collection with all the quizzes in the database.</returns>
        public IEnumerable<Quiz> GetAllQuizzesFromDatabase() => throw new NotImplementedException();

        /// <summary>
        /// Get the Quiz with the given Id from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Quiz.</param>
        /// <returns>The Quiz with the given <paramref name="id"/>.</returns>
        public Quiz GetQuizById(int id) 
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            IDataReader quizDataReader = GetQuizDataReaderById(id);
            Debug.Assert(quizDataReader != null);
            return LoadQuizFromDataReader(quizDataReader);
        }

        /// <summary>
        /// Return a quiz from the DataReader.
        /// </summary>
        /// <param name="quizDataReader">The DataReader that points to the Quiz data.</param>
        /// <returns>The Quiz pointed to by the DataReader.</returns>
        private Quiz LoadQuizFromDataReader(IDataReader quizDataReader)
        {
            if (quizDataReader is null)
                throw new ArgumentNullException(nameof(quizDataReader));
            Quiz quiz = new Quiz();
            using (dbConnection)
            using (dbCommand)
            using (quizDataReader)
            {
                while (quizDataReader.Read())
                {
                    quiz.Id = (int)quizDataReader["Id"];
                    quiz.Name = quizDataReader["Name"] as string;
                    quiz.Questions = LoadQuestionsFromDataReader(quizDataReader);
                }
            }

            return quiz;
        }

        /// <summary>
        /// Return the collection of Questions from the DataReader.
        /// </summary>
        /// <param name="quizDataReader">The DataReader to get the Questions from.</param>
        /// <returns>The collection of Questions.</returns>
        private static IEnumerable<Question> LoadQuestionsFromDataReader(IDataReader quizDataReader)
        {
            if (quizDataReader is null)
                throw new ArgumentNullException(nameof(quizDataReader));
            List<Question> questions = new List<Question>();
            while (quizDataReader.Read())
            {
                Question question = new Question()
                {
                    Id = (int)quizDataReader["QuestionId"],
                    Answers = LoadAnswersFromDataReader(quizDataReader),
                    DisplayText = quizDataReader["QuestionDisplayText"] as string,
                    Points = (int)quizDataReader["QuestionPoints"],
                };
                questions.Add(question);
            }

            return questions;
        }

        /// <summary>
        /// Return the collection of Answers from the DataReader.
        /// </summary>
        /// <param name="quizDataReader">The DataReader to get the Answers from.</param>
        /// <returns>The Answers from the DataReader.</returns>
        private static IEnumerable<Answer> LoadAnswersFromDataReader(IDataReader quizDataReader)
        {
            if (quizDataReader is null)
                throw new ArgumentNullException(nameof(quizDataReader));
            List<Answer> answers = new List<Answer>();
            while (quizDataReader.Read())
            {
                Answer answer = new Answer
                {
                    Id = (int)quizDataReader["AnswerId"],
                    DisplayText = quizDataReader["AnswerDisplayText"] as string,
                    IsCorrect = (bool)quizDataReader["AnswerIsCorret"],
                };
                answers.Add(answer);
            }
            return answers;
        }

        /// <summary>
        /// Return a DataReader with the Quiz given by the Id.
        /// </summary>
        /// <param name="id">The Id of the Quiz to return.</param>
        /// <returns>A DataReader with the Quiz given by the Id.</returns>
        private IDataReader GetQuizDataReaderById(int id)
        {
            //TODO consider moving the creation of the connection and object
            //into the using statements to gaurantee the IDisposable Dispose() method is called to close the connections.
            if (dbConnection is null)
                dbConnection = new SqlConnection(dbConnectionString);
            string getQuizStoredProcedure = "usp_GetQuizById";
            dbCommand = new SqlCommand(getQuizStoredProcedure, dbConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter storedProcedureParam = new SqlParameter("@id", id);
            dbCommand.Parameters.Add(storedProcedureParam);
            if (dbConnection.State != ConnectionState.Open)
                dbConnection.Open();
            IDataReader quizDataReader = dbCommand.ExecuteReader();
            return quizDataReader;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    dbConnection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~QuizSqlDataAccess() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
