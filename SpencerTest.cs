using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace ldstesting
{
    [TestClass]
    public class SpencerTest
    {
        #region Static Variables
        static string test = "https://test.lds.org";
        static string stage = "https://stage.lds.org";
        static string prod = "https://www.lds.org";
        static string bishop = "ngiwb2";
        static string password = "password1";

        
        #endregion

        #region Test Variables
        string lane = stage;
        IWebDriver driverWeb = new ChromeDriver();
        
        #endregion
        
        [TestMethod]
        #region Tests
        public void CanaryTest()
        {
            driverWeb.Navigate().GoToUrl(lane);
            Login(bishop, password);
            string[] CanarySites = new string[]  {
                                                lane+"/general-conference/canary?lang=eng",
                                                lane+"/broadcasts/face-to-face/canary",
                                                lane+"/topics/canary"
                                                };
            string[] HealthCheckSites = new string[] {
                                                        lane+"/mycallling/healthcheck",
                                                        lane+"/notes/healthcheck",
                                                        "https://gospel-living.app-test.lds.org/gospel-living/healthcheck"
                                                     };

            /*foreach (string canary in CanarySites)
            {
                driverWeb.Navigate().GoToUrl(canary);
                driverWeb.FindElement(By.XPath("/html/body/h2[1]/span[@class='ok']")).Text.Equals("OK");
            }*/
            foreach (string healthcheck in HealthCheckSites)
            {
                driverWeb.Navigate().GoToUrl(healthcheck);
                Assert.IsTrue(driverWeb.FindElement(By.XPath("/html/body/pre")).Text.Contains(":200"));
            }

            driverWeb.Navigate().GoToUrl(lane);            
            LogOut();
            driverWeb.Quit();
        }

        [TestMethod]
        public void NotesLogin()
        {
            driverWeb.Navigate().GoToUrl(lane);
            Login(bishop, password);

            driverWeb.Navigate().GoToUrl(lane +"/notes");
            LogOut();

            driverWeb.Navigate().GoToUrl(lane + "/notes");
            Login(bishop, password);
            driverWeb.Quit();
        }
        [TestMethod]
        public void NotesAddDelete()
        {
            driverWeb.Navigate().GoToUrl(lane + "/notes");
            Login(bishop, password);
            //Testing Adding a Notebook but cancelling before it goes through
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/nav[@class='nav-1qrGu']/a[@class='navItem-R2ww_'][2]")).Click();
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/header[@class='header-1HKxv']/button[@class='button-1P1nj'][2]")).Click();
            driverWeb.FindElement(By.ClassName("input-cSag8")).SendKeys("Testing42");
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/div[@class='addForm-3Y0rf']/form[@class='form-10K5b']/div[@class='buttons-3oACv']/button[@class='cancelButton-3mUve button-2CQyY']")).Click();
            //Adding a new notebook Testing 42
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/header[@class='header-1HKxv']/button[@class='button-1P1nj'][2]")).Click();
            driverWeb.FindElement(By.ClassName("input-cSag8")).SendKeys("Testing42");                        
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/div[@class='addForm-3Y0rf']/form[@class='form-10K5b']/div[@class='buttons-3oACv']/button[@class='doneButton-3gnA2 button-2CQyY']")).Click();
            //Adding an annotation in the new Notebook(Folder)
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/div[@class='list-3fovU']/section/ol[@class='list-1vjwm']/li[@class='item-33mKs'][1]")).Click();
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3aPLG']/div[@class='list-bHFUX']/div/div[@class='root-1ib7H']/p/button[@class='sc-chPdSV ePQlcl']")).Click();
            driverWeb.FindElement(By.ClassName("input-2h0hv")).SendKeys("Automated Test");
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='mainPanel-2Cxk6']/section/div[@class='note-1mYEo']/div[@class='root-2Mhw-']/div[@class='editor-1VfHk']/div[@class='DraftEditor-root']/div[@class='DraftEditor-editorContainer']/div[@class='notranslate public-DraftEditor-content']")).SendKeys("Testing Annotation");
            
            //Adding a second Notebook for the annotation to be included
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='mainPanel-2Cxk6']/section/div[@class='meta-eE0-d']/div[@class='IconAndFriends-3V8Cz'][1]/div[@class='friends-3xe6I']/div[@class='TagList-nD_xg']/div[@class='list-2ijva']/div[@class='SearchInput-17a9O']/div[@class='bar-1wNqx']/input[@class='input-3iYHK']")).SendKeys("Study");
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='mainPanel-2Cxk6']/section/div[@class='meta-eE0-d']/div[@class='IconAndFriends-3V8Cz'][1]/div[@class='friends-3xe6I']/div[@class='TagList-nD_xg']/div[@class='list-2ijva']/div[@class='SearchInput-17a9O']/div[@class='suggestions-2DRWA']/ul[@class='list-283-_']/li[@class='item-1EvVl'][1]/button[@class='highlighted-nMDTO link-2zBfD']/mark")).Click();            

            //Adding a Tag then deleting tag off of annotation
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='mainPanel-2Cxk6']/section/div[@class='meta-eE0-d']/div[@class='IconAndFriends-3V8Cz'][2]/div[@class='friends-3xe6I']/div[@class='TagList-nD_xg']/div[@class='list-2ijva']/div[@class='SearchInput-17a9O']/div[@class='bar-1wNqx']/input[@class='input-3iYHK']")).SendKeys("Test");
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='mainPanel-2Cxk6']/section/div[@class='meta-eE0-d']/div[@class='IconAndFriends-3V8Cz'][2]/div[@class='friends-3xe6I']/div[@class='TagList-nD_xg']/div[@class='list-2ijva']/div[@class='SearchInput-17a9O']/div[@class='suggestions-2DRWA']/ul[@class='list-283-_']/li[@class='item-1EvVl'][1]")).Click();
            //remove annotation from Study Folder
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='mainPanel-2Cxk6']/section/div[@class='meta-eE0-d']/div[@class='IconAndFriends-3V8Cz'][1]/div[@class='friends-3xe6I']/div[@class='TagList-nD_xg']/div[@class='list-2ijva']/div[@class='tag-21CpC'][2]/span[@class='outer-1nfCE']/span[@class='inner-2-017']/button[@class='button-3iteG']")).Click();
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='mainPanel-2Cxk6']/section/div[@class='meta-eE0-d']/div[@class='IconAndFriends-3V8Cz'][2]/div[@class='friends-3xe6I']/div[@class='TagList-nD_xg']/div[@class='list-2ijva']/div[@class='tag-21CpC']/span[@class='outer-1nfCE']/span[@class='inner-2-017']/button[@class='button-3iteG']")).Click();
            //Deleting created folder
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3aPLG']/header[@class='header-nP1uj']/a[@class='back-2IjWh']/div[1]")).Click();
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/header[@class='header-1HKxv']/button[@class='button-1P1nj'][1]")).Click();
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/div[@class='list-3fovU']/section/ol[@class='list-1vjwm']/li[@class='item-33mKs'][1]/div/div[@class='DeleteConfirmation-bqPke']/button[@class='trashCan-TsWus']")).Click();
            driverWeb.FindElement(By.XPath("/html/body[@class='pf-popupSetup pf-search__where--exists pf-loggedin']/div[@id='app']/div[@class='app-3RHf6']/div/main[@class='layout-2vjVc']/div[@class='panels-3f5HF']/div[@class='panelLayout-yb0ud']/div[@class='sidebar-1qjsJ']/div[@class='sidebarContent-3C1sJ']/div[@class='sidebarContentLayout-2aSRK']/section[@class='root-3s3MP']/div[@class='list-3fovU']/section/ol[@class='list-1vjwm']/li[@class='item-33mKs'][1]/div/div[@class='DeleteConfirmation-bqPke']/button[@class='button-1JXyM slideIn-oq7Y8 sc-EHOje hAcMdt']")).Click();

            LogOut();
            driverWeb.Quit();
        }

        #endregion


        #region Helper Methods
        public void Login(string username, string password)
        {
            string title = driverWeb.Title.ToString();
            //If not on login page this will navigate to the login page
            if ((driverWeb.Title.ToString()) != "Sign in")
            {
                driverWeb.FindElement(By.ClassName("pf-personal__text")).Click();
                driverWeb.FindElement(By.ClassName("pf-sign-in")).Click();
            }
            driverWeb.FindElement(By.Id("IDToken1")).SendKeys(username);
            driverWeb.FindElement(By.Id("IDToken2")).SendKeys(password);
            driverWeb.FindElement(By.Id("login-submit-button")).Click();
        }

        public void LogOut()
        {
         driverWeb.FindElement(By.ClassName("pf-personal__text")).Click();
            if (driverWeb.FindElement(By.ClassName("pf-sign-out")).Displayed == true)
            {
                driverWeb.FindElement(By.ClassName("pf-sign-out")).Click();
            }
            driverWeb.Navigate().GoToUrl(lane);
        }
        #endregion

    }
}