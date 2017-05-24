using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;




namespace WebDriverTesting
{
    public class TestCases : IDisposable
    {
        public TestCases()
        {
            _driver = new ChromeDriver();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [Fact]
        public void FixMe()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");

            var posts = _driver.FindElementsByClassName("post-title");
            var secondPost = posts[1];
            var firstNoteTitle = secondPost.FindElement(By.TagName("a")).Text;
            Assert.Equal("Vivamus aliquam feugiat", firstNoteTitle);

            
        }
        public void Dispose()
        {
            _driver.Quit();
        }
        private ChromeDriver _driver;
    }
}
