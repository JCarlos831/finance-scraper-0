// https://www.youtube.com/watch?v=cNKi0Pl5wbc

using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace finance_scraper_0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("/Users/JuanCMontoya/Projects/vscode/csharp/finance-scraper-0/bin/Debug/netcoreapp2.0");
            IWebDriver driver = new FirefoxDriver(service);

            driver.Url = "https://login.yahoo.com/config/login?.intl=us&.lang=en-US&.src=finance&.done=https%3A%2F%2Ffinance.yahoo.com%2F";

            driver.Manage().Window.Maximize();
            
            driver.FindElement(By.Id("login-username")).SendKeys("testfinance@yahoo.com" + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("login-passwd")).Click();
            driver.FindElement(By.Id("login-passwd")).SendKeys("3eggwhites6" + Keys.Enter);

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[1]/div[2]/div[1]/div/div/div/div/div/div/div/nav/div/div/div/div[3]/div/div[1]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("/html/body/dialog/section/button")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/section/section/div[2]/table/tbody/tr[1]/td[1]/a")).Click();

            IList<IWebElement> stockNames =  driver.FindElements(By.ClassName("_61PYt"));

            System.Console.WriteLine("Total number of stocks in portfolio: " + stockNames.Count);
            System.Console.WriteLine("You have the following stocks:");

            foreach (var stockName in stockNames)
            {
                Console.WriteLine(stockName.Text);
            }

            System.Console.WriteLine("\n");

            driver.Close();   
        }
    }
}
