using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace webdriverdotnet
{
    [TestClass]
    public class SpencerTest
    {
        #region Static Variables
        static string test = "https://test.lds.org";
        static string stage = "https://stage.lds.org";
        static string prod = "https://www.lds.org";
        
        #endregion

        #region Test Variables
        string lane = stage;
        IWebDriver driverWeb = new ChromeDriver();
        
        #endregion
        
        [TestMethod]
        #region Tests
        public void TestMethod1()
        {
            string[] CanarySite = new string[]  {"https://www.lds.org/general-conference/canary?lang=eng",
                                                "https://www.lds.org/broadcasts/face-to-face/canary",
                                                "https://www.lds.org/topics/canary"
                                            };

            foreach (string canary in CanarySite)
            {
                driverWeb.Navigate().GoToUrl(canary);
                Assert.IsTrue(driverWeb.FindElement(By.ClassName("ok")).Enabled.Equals(true));
            }

            driverWeb.Quit();
        }
        [TestMethod]
        public void NotesLogin()
        {
            driverWeb.Navigate().GoToUrl(lane);
            Login();

            driverWeb.Navigate().GoToUrl(lane +"/notes");
            LogOut();

            driverWeb.Navigate().GoToUrl(lane + "/notes");
            Login();
            driverWeb.Quit();
        }
        #endregion

        #region Helper Methods
        public void Login()
        {
            string title = driverWeb.Title.ToString();
            //If not on login page this will navigate to the login page
            if ((driverWeb.Title.ToString()) != "Sign in")
            {
                driverWeb.FindElement(By.ClassName("pf-personal__text")).Click();
                driverWeb.FindElement(By.ClassName("pf-sign-in")).Click();
            }
            driverWeb.FindElement(By.Id("IDToken1")).SendKeys("ngiwb1");
            driverWeb.FindElement(By.Id("IDToken2")).SendKeys("password1");
            driverWeb.FindElement(By.Id("login-submit-button")).Click();
        }

        public void LogOut()
        {
            driverWeb.FindElement(By.ClassName("pf-personal__text")).Click();
            driverWeb.FindElement(By.ClassName("pf-sign-out")).Click();
            driverWeb.Navigate().GoToUrl(lane);
        }
        #endregion

    }
}