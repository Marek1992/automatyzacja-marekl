using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium.Support.UI;

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
        protected void WaitForIWebElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        protected void WaitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
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
        [Fact]
        public void Zalogowanie_Dodatnie_Notki_I_Sprawdzenie_Czy_Notka_Wyswietla_Sie_Prawidlowo()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/wp-admin/");
            var login = _driver.FindElementById("user_login");
            login.Clear();
            WaitForIWebElementPresent(login, 5);
            login.SendKeys("autotestdotnet@gmail.com");

            var password = _driver.FindElementById("user_pass");
            password.Clear();
            WaitForIWebElementPresent(password, 5);
            password.SendKeys("codesprinters2016");

            _driver.FindElementById("wp-submit").Click();
            _driver.FindElementById("menu-posts").Click();
            

            var newPost = _driver.FindElementByClassName("page-title-action");
            newPost.Click();
            
            var newUniqueName =  Guid.NewGuid().ToString();
            var titlePost = _driver.FindElementByName("post_title");
            titlePost.SendKeys(newUniqueName);
            

            var postText = _driver.FindElementByName("content");
            postText.SendKeys("NowyPostMarek");
            

            var publish = _driver.FindElementByName("publish");
            publish.Click();

            var publishUrl = _driver.FindElementByCssSelector("#sample-permalink > a").GetAttribute("href");


            var avatar = _driver.FindElementByCssSelector(".avatar.avatar-32");
            avatar.Click();
            WaitForIWebElementPresent(avatar, 5);

            var signOut = _driver.FindElementByClassName("ab-sign-out");
            signOut.Click();

            _driver.Navigate().GoToUrl(publishUrl);

            var title = _driver.FindElementByClassName("entry-title").Text;
            Assert.Equal(newUniqueName, title);

        }
        public void Dispose()
        {
            _driver.Quit();
        }
        private ChromeDriver _driver;
    }
}
