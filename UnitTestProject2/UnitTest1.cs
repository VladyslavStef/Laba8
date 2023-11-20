using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;



class GitHub
{

    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;
    public GitHub(ref IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    public void GoTo(string path)
    {
        driver.Navigate().GoToUrl(path);
    }
    public void Click(string path)
    {
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(path))).Click();

    }
    public bool IsPageLoaded()
    {
        return driver.Url.Contains("https://academy.ultimateqa.com/java-sdet");
    }


}

class Class_for_change
{

    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;
    public Class_for_change(ref IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    public void SendKeys(string id, string key)
    {
        var Send = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        Send.SendKeys(key);
        Send.SendKeys(Keys.Enter);
    }
    public void Click(string path)
    {
        var Cl = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(path)));

        Cl.Click();
    }
    public bool IsPageLoaded()
    {
        return driver.Url.Contains("https://academy.ultimateqa.com/java-sdet");
    }

}




[TestFixture]
public class Tests_Class
{

    IWebDriver driver;
    Class_for_change Change;
    GitHub hub;
    [SetUp]
    public void SetUp()
    {

        new DriverManager().SetUpDriver(new EdgeConfig());

        driver = new EdgeDriver();
        driver.Manage().Window.Maximize();
        hub = new GitHub(ref driver);
        hub.GoTo("https://github.com");
        Change = new Class_for_change(ref driver);
    }


    [Test]
    public void TestMethod()
    {

        hub.Click("(//a[@class = 'HeaderMenu-link HeaderMenu-link--sign-up flex-shrink-0 d-none d-lg-inline-block no-underline border color-border-default rounded px-2 py-1'])[1]");

        Change.SendKeys("email", "VladHJd@gmail.com");
        Change.Click("(//button[@class = 'js-continue-button signup-continue-button form-control px-3 width-full width-sm-auto mt-4 mt-sm-0'])[1]");
        Change.SendKeys("password", "12345678akdj");
        Change.Click("(//button[@class = 'js-continue-button signup-continue-button form-control px-3 width-full width-sm-auto mt-4 mt-sm-0'])[2]");
        Change.SendKeys("login", "vladstef32");
        Change.Click("(//button[@class = 'js-continue-button signup-continue-button form-control px-3 width-full width-sm-auto mt-4 mt-sm-0'])[3]");
        Change.Click("(//button[@class = 'js-continue-button signup-continue-button form-control px-3 width-full width-sm-auto mt-4 mt-sm-0'])[4]");

    }
}