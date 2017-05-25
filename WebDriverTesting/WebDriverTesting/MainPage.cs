﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using Xunit;

namespace WebDriverTesting
{
    internal class MainPage
    {
        public static IWebDriver Browser = WebBrowser.Driver;
        internal static void GoTo()
        {
            Browser.Navigate().GoToUrl(Configuration.BaseUrl);
        }

        internal static void AssertNotLoggedIn()
        {
            Assert.Throws<NoSuchElementException>(() => Browser.FindElement(By.Id("wpadminbar")));
        }

        internal static void ShowNextPage()
        {
            var infiniteHandle = (By.Id("infinite-handle"));
            var olderPosts = Browser.FindElement(infiniteHandle);
            var button = olderPosts.FindElement(By.TagName("button"));
            button.Click();
            WaitForElementPresent(infiniteHandle);
        }

        internal static void LeaveComment(Comment exampleComment)
        {
           var comments =  Browser.FindElements(By.ClassName("comments-link"));
           var secondComment = comments[1];
           var a = secondComment.FindElement(By.TagName("a"));
           var leaveCommentUrl = a.GetAttribute("href");

           Browser.Navigate().GoToUrl(leaveCommentUrl);

            var commentBox = Browser.FindElement(By.Id("comment"));
            commentBox.Click();
            commentBox.SendKeys(exampleComment.Text);

            var mailField = Browser.FindElement(By.Id("email"));
            mailField.SendKeys(exampleComment.Email);

            var authorField = Browser.FindElement(By.Id("author"));
            authorField.SendKeys(exampleComment.author);

            var submitelement = Browser.FindElement(By.Id("comment-submit"));
            submitelement.Click();

        }

        internal static void AssertCommentExist(Comment exampleComment)
        {
            var comments = Browser.FindElements(By.CssSelector(".comment-body"));
            var comment = comments.Single(c =>

               c.FindElement(By.TagName("cite")).Text == exampleComment.author
               &&
               c.FindElement(By.TagName("p")).Text == exampleComment.Text

            );
        }

        protected static void WaitForElementPresent(By by)
        {
            WebDriverWait wait = new WebDriverWait(Browser,
                TimeSpan.FromSeconds(Configuration.ImplicitWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected static void WaitForElementPresent(IWebElement by)
        {
            WebDriverWait wait = new WebDriverWait(Browser,
                TimeSpan.FromSeconds(Configuration.ImplicitWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}