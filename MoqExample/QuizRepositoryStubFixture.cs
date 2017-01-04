using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Interfaces;
using DataAccess.Data.Stub;
using QuizIt.Domain;
using DataAccess.Repositories;

namespace MoqExample
{
    [TestClass]
    public class QuizRepositoryStubFixture : QuizTestBase
    {
        private IQuizRepository quizRepository;
        private IQuizDataAccess quizSqlDataAccess;
        private int idCounter;
        private QuizSqlDataAccessStub dataAccessStub;

        [TestInitialize]
        public void TestInitialize()
        {
            idCounter = 1;
            quizRepository = PrepareQuizRepositoryForTesting();
        }

        [TestMethod]
        public void GetByIdReturnQuiz()
        {
            Assert.IsNotNull(quizRepository, "The quiz repository is null");
            Quiz quiz = quizRepository.GetById(1);
            Assert.IsNotNull(quiz, "QuizRepository.GetById(1) returned null");
            Assert.AreEqual(1, quiz.Id, "quiz.Id should be 1");
        }

        private IQuizRepository PrepareQuizRepositoryForTesting()
        {
            IQuizDataAccess dataAccessStub = GetQuizDataAccessStub();
            quizRepository = new QuizRepository(dataAccessStub);
            return quizRepository;
        }

        private IQuizDataAccess GetQuizDataAccessStub()
        {
            return new QuizSqlDataAccessStub();
        }
    }
}
