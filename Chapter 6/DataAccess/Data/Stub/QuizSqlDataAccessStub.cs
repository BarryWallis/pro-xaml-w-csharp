using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using MoqExample;
using QuizIt.Domain;

namespace DataAccess.Data.Stub
{
    class QuizSqlDataAccessStub : QuizTestBase, IQuizDataAccess
    {
        /// <summary>
        /// Get a collection containing all the quizzes in the database.
        /// </summary>
        /// <returns>A collection with all the quizzes in the database.</returns>
        public IEnumerable<Quiz> GetAllQuizzesFromDatabase() => PrepareTestQuizCollection();

        /// <summary>
        /// Get the Quiz with the given Id from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Quiz.</param>
        /// <returns>The Quiz with the given <paramref name="id"/>.</returns>
        public Quiz GetQuizById(int id) 
        {
            Quiz quiz = PrepareTestQuiz();
            quiz.Id = id;
            return quiz;
        }
    }
}
