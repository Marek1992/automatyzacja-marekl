using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTesting
{
    public class BlogPostTests : IDisposable
    {
        private Comment ExampleComment = new Comment
        {
            author = Guid.NewGuid().ToString(),
            Email = "cos@cos.com",
            Text = Guid.NewGuid().ToString()
        };

        [Fact]
        public void When_User_Is_Not_Logged_In_Can_Add_Comment_On_Second_Note()
        {
            MainPage.GoTo();
            MainPage.AssertNotLoggedIn();
            MainPage.ShowNextPage();
            MainPage.LeaveComment(ExampleComment);
            MainPage.AssertCommentExist(ExampleComment);
 
        }
        public void Dispose()
        {
            WebBrowser.Driver.Quit();
        }

    }
}
