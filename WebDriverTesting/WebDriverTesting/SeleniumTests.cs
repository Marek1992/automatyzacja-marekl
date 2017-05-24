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
            Assert.Equal(true, false);
        }
        public void Dispose()
        {
            _driver.Quit();
        }
        private ChromeDriver _driver;
    }
}
