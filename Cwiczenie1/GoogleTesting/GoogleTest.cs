using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace GoogleTesting
{
    public class GoogleTest : IDisposable
    {
        private ChromeDriver _driver;

        public GoogleTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage()
                .Timeouts()
                .ImplicitlyWait(TimeSpan.FromSeconds(5));

        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void Hello_Test()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElementById("lst-ib").SendKeys("code sprinters");
            _driver.FindElementById("_fZl").Click();
            Thread.Sleep(1000);
            var result = _driver.FindElementByXPath(@"//div/*/a[@href='http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);

            
        }
    }
}
