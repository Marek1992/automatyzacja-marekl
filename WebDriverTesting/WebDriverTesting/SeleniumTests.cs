using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        [Fact]
        public void Zalogowanie_Dodatnie_Notki_I_Sprawdzenie_Czy_Notka_Wyswietla_Sie_Prawidlowo()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/wp-admin/");
            var login = _driver.FindElementById("user_login");
            login.Clear();
            Thread.Sleep(1000);
            login.SendKeys("autotestdotnet@gmail.com");

            var password = _driver.FindElementById("user_pass");
            password.Clear();
            Thread.Sleep(1000);
            password.SendKeys("codesprinters2016");

            _driver.FindElementById("wp-submit").Click();
            Thread.Sleep(1000);

            _driver.FindElementById("menu-posts").Click();
            Thread.Sleep(1000);

            var newPost = _driver.FindElementByClassName("page-title-action");
            Thread.Sleep(1000);
            newPost.Click();

            Thread.Sleep(1000);

            var newUniqueName =  Guid.NewGuid().ToString();
            var titlePost = _driver.FindElementByName("post_title");
            titlePost.SendKeys(newUniqueName);
            Thread.Sleep(1000);

            var postText = _driver.FindElementByName("content");
            postText.SendKeys("NowyPostMarek");
            Thread.Sleep(1000);

            var publish = _driver.FindElementByName("publish");
            publish.Click();
            Thread.Sleep(1000);

            var avatar = _driver.FindElementByCssSelector(".avatar.avatar-32");
            avatar.Click();
            Thread.Sleep(1000);

            var signOut = _driver.FindElementByClassName("ab-sign-out");
            Thread.Sleep(1000);
            signOut.Click();
            Thread.Sleep(1000);

            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");

            var title = _driver.FindElementByXPath("//a[text()='"+ newUniqueName +"']").Text;
            Thread.Sleep(1000);
            Assert.Equal(newUniqueName, title);

        }
        public void Dispose()
        {
            _driver.Quit();
        }
        private ChromeDriver _driver;
    }
}
