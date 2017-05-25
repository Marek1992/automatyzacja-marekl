using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

 namespace WebDriverTesting
{
    public class Selenium2 : IDisposable
    {
    private readonly string _exampleTitle;
    private static string ExampleContent => @"Przykladowy teks w obszarze tekstowym";

    public Selenium2()
    {
        _exampleTitle = Guid.NewGuid().ToString();
    }

    [Fact]
    public void When_administrator_publish_new_note_unregistered_user_can_view_that_note_on_a_blog()
    {
        Administrator.GoTo();
        Administrator.Login(Credentials.Valid);
        var url = Administrator.CreateNewPost(_exampleTitle, ExampleContent);
        Administrator.Logout();

        Note.GoTo(url);
        Note.AssertPostExist(_exampleTitle);
    }

    public void Dispose()
    {
        Browser.Get().Quit();
    }
}

internal class Browser
{
    static Browser()
    {
        Driver = new ChromeDriver();
            Driver.Manage()
                .Window
            .Size = new System.Drawing.Size(1600, 1024);
            Driver.Manage()
            .Timeouts()
            .ImplicitWait = TimeSpan.FromSeconds(5);
    }
    private static readonly ChromeDriver Driver;

    internal static ChromeDriver Get()
    {
        return Driver;
    }
}

internal class Credentials
{
    public static WpCredentials Valid => new WpCredentials
    {
        UserName = "autotestdotnet@gmail.com",
        Password = "codesprinters2017"
    };

    public static WpCredentials InValid => new WpCredentials
    {
        UserName = "testowanieDotNet",
        Password = "InValidPassword"
    };
}

public class WpCredentials
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

internal class Note
{
    private static readonly ChromeDriver Driver = Browser.Get();

    internal static void AssertPostExist(string expectedTitle)
    {
        var singlePostTitle = Driver.FindElementByXPath("//header/h1").Text;
        Assert.Equal(singlePostTitle, expectedTitle);
    }

    internal static void GoTo(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }
}

internal class Administrator
{
    private static readonly ChromeDriver Driver = Browser.Get();

    internal static string CreateNewPost(string exampleTitle, string exampleContent)
    {
        Driver.FindElementByCssSelector(".wp-menu-image.dashicons-before.dashicons-admin-post").Click();
        Driver.FindElementByLinkText("Add New").Click();

        var title = Driver.FindElementById("title");
        title.Click();
        title.SendKeys(exampleTitle);

        var content = Driver.FindElementById("content");
        content.Click();
        content.SendKeys(exampleContent);
        Driver.FindElementByCssSelector(".edit-slug.button.button-small.hide-if-no-js");
        WaitForElementPresent(By.CssSelector(".edit-slug.button.button-small.hide-if-no-js"),20);
        Driver.FindElementById("publish").Click();
        WaitForElementPresent(By.Id("sample-permalink"), 20);
        return Driver.FindElementById("sample-permalink")
            .FindElement(By.XPath("a")).GetAttribute("href");
    }

    internal static void GoTo()
    {
        Driver.Navigate()
            .GoToUrl("https://autotestdotnet.wordpress.com/wp-admin");
    }

    internal static void Login(WpCredentials credentials)
    {
        var login = Driver.FindElementById("user_login");
        login.Click();
        login.SendKeys(credentials.UserName);

        var pass = Driver.FindElementById("user_pass");
        pass.Click();
        pass.SendKeys(credentials.Password);

        Driver.FindElementById("wp-submit").Click();

    }

    internal static void Logout()
    {
        var logout = Driver.FindElementByCssSelector(".avatar.avatar-32");
        logout.Click();

        Driver.FindElementByCssSelector(".ab-sign-out").Click();
    }

    protected static void WaitForElementPresent(By by, int seconds)
    {
        WebDriverWait wait = new WebDriverWait(Driver,
            TimeSpan.FromSeconds(seconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(by));
    }

    protected static void WaitForElementPresent(IWebElement by, int seconds)
    {
        WebDriverWait wait = new WebDriverWait(Driver,
            TimeSpan.FromSeconds(seconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(by));
    }
}

}
