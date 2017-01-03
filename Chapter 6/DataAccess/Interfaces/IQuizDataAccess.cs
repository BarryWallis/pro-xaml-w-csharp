using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizIt.Domain;

namespace DataAccess.Interfaces
{
    public interface IQuizDataAccess
    {
        /// <summary>
        /// Get the Quiz with the given Id from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Quiz.</param>
        /// <returns>The Quiz with the given <paramref name="id"/>.</returns>
        Quiz GetQuizById(int id);

        /// <summary>
        /// Get a collection containing all the quizzes in the database.
        /// </summary>
        /// <returns>A collection with all the quizzes in the database.</returns>
        IEnumerable<Quiz> GetAllQuizzesFromDatabase();
    }
}
