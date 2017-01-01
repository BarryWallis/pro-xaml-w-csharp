using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: CLSCompliant(true)]
namespace ApressXaml.Usb.UnitTests
{
    [TestClass]
    public class GreetingTests
    {
        private IUserLogOnService userLoginService;

        [TestInitialize]
        public void TestInit()
        {
            userLoginService = new UserLogOnService();
            Assert.IsNotNull(userLoginService);
        }

        [TestMethod]
        public void IfNameLengthGreaterThan0ThenServiceReturnsMessage()
        {
            string validName = "Buddy";
            string actualGreeting = userLoginService.GreetUser(validName);
            string expectedGreeting = $"Hello {validName}!";

            Assert.AreEqual(expectedGreeting, actualGreeting, "The user greeting is incorrect");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNameIsNullThenThrowArgumentNullException()
        {
            string validName = null;
            userLoginService.GreetUser(validName);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNameIsEmptyThenThrowArgumentNullException()
        {
            string validName = "";
            userLoginService.GreetUser(validName);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNameIsWhiteSpaceThenThrowArgumentNullException()
        {
            string validName = "   ";
            userLoginService.GreetUser(validName);
            Assert.Fail();
        }
    }
}
