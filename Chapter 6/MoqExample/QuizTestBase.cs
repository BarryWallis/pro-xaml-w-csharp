using System;
using System.Collections.Generic;
using QuizIt.Domain;

namespace MoqExample
{
    public abstract class QuizTestBase
    {
        private int idCounter = 0;

        /// <summary>
        /// Create a Quiz to be used in unit testing.
        /// </summary>
        /// <returns>The Quiz to be used in unit testing.</returns>
        protected virtual Quiz PrepareTestQuiz()
        {
            Quiz testQuiz = new Quiz()
            {
                Id = idCounter++,
                Name = $"Test Quiz #{idCounter}",
            };

            testQuiz.Questions = PrepareQuizQuestions();
            return testQuiz;
        }

        /// <summary>
        /// Create a colletion of Quiz Questions.
        /// </summary>
        /// <returns>The collection of Quiz Questions.</returns>
        protected virtual IEnumerable<Question> PrepareQuizQuestions()
        {
            List<Question> questions = new List<Question>
            {
                PrepareQuestion(),
                PrepareQuestion(),
                PrepareQuestion(),
            };

            return questions;
        }

        /// <summary>
        /// Create a Question for testing.
        /// </summary>
        /// <returns>The test question.</returns>
        protected virtual Question PrepareQuestion() => new Question
        {
            Id = idCounter++,
            DisplayText = $"Question # {idCounter}.",
            Points = 10,
            Answers = PrepareAnswers(),
        };

        /// <summary>
        /// Create a collection of Answers.
        /// </summary>
        /// <returns>The collection of Answers.</returns>
        protected virtual IEnumerable<Answer> PrepareAnswers() => new List<Answer>
            {
                PrepareAnswer("Incorrect answer 1.", false),
                PrepareAnswer("Incorrect answer 2.", false),
                PrepareAnswer("Correct answer.", true),
                PrepareAnswer("Incorrect answer 3.", false),
            };

        /// <summary>
        /// Create an Answer for testing.
        /// </summary>
        /// <param name="displayText">The text to display as the answer.</param>
        /// <param name="isCorrect">True if the answer is correct; otherwise false.</param>
        /// <returns></returns>
        protected virtual Answer PrepareAnswer(string displayText, bool isCorrect) => new Answer
        {
            Id = idCounter++,
            DisplayText = displayText,
            IsCorrect = isCorrect,
        };

        /// <summary>
        /// Create a collection of test Quizzes.
        /// </summary>
        /// <returns>The collection of test Quizzes.</returns>
        protected virtual IEnumerable<Quiz> PrepareTestQuizCollection() => new List<Quiz>
        {
            PrepareTestQuiz(),
            PrepareTestQuiz(),
            PrepareTestQuiz(),
        };
    }
}
