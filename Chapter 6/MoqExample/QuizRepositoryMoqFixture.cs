using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuizIt.Domain;

namespace MoqExample
{
    [TestClass]
    public class QuizRepositoryMoqFixture : QuizTestBase
    {
        private IQuizRepository quizRepository;
        private IQuizDataAccess quizSqlDataAccess;
        private int idCounter;
        private Mock<IQuizDataAccess> mockingService;

        [TestInitialize]
        public void TestInitialize()
        {
            idCounter = 1;
            quizRepository = PrepareQuizRepositoryForTesting();
        }

        [TestMethod]
        public void GetAllReturnListOfQuizzes()
        {
            Assert.IsNotNull(quizRepository, $"{nameof(quizRepository)} is null");
            IEnumerable<Quiz> quizzes = quizRepository.GetAll();
            Assert.IsNotNull(quizzes, $"{nameof(quizRepository.GetAll)} returned null");
            Assert.IsTrue(quizzes is List<Quiz>, $"{nameof(quizzes)} is not a List<Quiz>");
            int quizCount = (quizzes as List<Quiz>).Count;

            Debug.Assert(mockingService != null);
            mockingService.Verify(q => q.GetAllQuizzesFromDatabase());
            Assert.AreEqual(3, quizCount, $"Expected 3 but actual count is {quizCount}");
        }

        private IQuizRepository PrepareQuizRepositoryForTesting()
        {
            PrepareMockedQuizDataAccess();
            quizRepository = new QuizRepository(quizSqlDataAccess);
            Debug.Assert(quizRepository != null);
            return quizRepository;
        }

        private void PrepareMockedQuizDataAccess()
        {
            mockingService = new Mock<IQuizDataAccess>();
            IEnumerable<Quiz> returnQuizList = PrepareTestQuizCollection();
            mockingService
                .Setup<IEnumerable<Quiz>>(q => q.GetAllQuizzesFromDatabase())
                .Returns(returnQuizList);
            quizSqlDataAccess = mockingService.Object;
        }
    }
}
