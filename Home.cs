using OpenQA.Selenium;

namespace webdriverdotnet
{
    public class Home
    {
        private IWebDriver _driver { get; set; }
        public Home(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement Search => _driver.FindElement(By.Name("q"));
    }
}