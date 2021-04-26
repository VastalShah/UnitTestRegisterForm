using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumProject
{
    [TestClass]
    public class UnitTestForAngularApp
    {
        [TestMethod]
        public void RegistrationWorks()
        {
            using (var driver = new ChromeDriver())
            {
                bool isFormValid;
                driver.Navigate().GoToUrl("http://localhost:4200/Signup");

                var name = driver.FindElementById("username");
                Assert.IsNotNull(name);
                name.SendKeys("Vatsal");

                var email = driver.FindElementById("email");
                Assert.IsNotNull(email);
                email.SendKeys("vatsal@gmail.com");

                var password = driver.FindElementById("password");
                Assert.IsNotNull(password);
                password.SendKeys("1234567");

                var confirmPassword = driver.FindElementById("confirmPassword");
                Assert.IsNotNull(confirmPassword);
                confirmPassword.SendKeys("1234567");

                var formsubmitbtn = driver.FindElementById("formsubmit");
                Assert.IsNotNull(formsubmitbtn);
                formsubmitbtn.Click();


                try
                {
                    var expectedText = "You have succesfully registered";
                    var alert = driver.SwitchTo().Alert();
                    Assert.AreEqual(expectedText, alert.Text);
                    alert.Accept();
                    isFormValid = true;
                }
                catch (AssertFailedException)
                {
                    isFormValid = false;
                    Console.WriteLine("Form is not submitted");
                }

                if (isFormValid)
                {
                    var homeLink = driver.FindElementById("home");
                    homeLink.Click();
                }
            }
        }
    }
}
