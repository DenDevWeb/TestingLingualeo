using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TestingLingualeo.Exception;
using TestingLingualeo.Helpers;
using TestingLingualeo.Models;

namespace TestingLingualeo.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url =
            @"https://lingualeo.com/ru/";

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div/div/div[1]/div[3]/div[2]/div[2]/div[2]/div[1]/input")] 
        private IWebElement _emailInput;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div/div/div[1]/div[3]/div[2]/div[2]/div[2]/div[2]/input")] 
        private IWebElement _passwordInput;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div/div/div[1]/div[3]/div[2]/div[2]/div[2]/div[4]/button")] 
        private IWebElement _submitButton;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div/div/div[1]/div[3]/div[2]/div[2]/div[2]/div[6]")] 
        private IWebElement _have_an_account;
        

        private static readonly string PASSWORD_EMPTY = "/html/body/div[4]/div[2]/div/div[3]/form/div[2]/p";
        
        private static readonly string EMAIL_OR_PASSWORD_INCORRECT ="/html/body/div[1]/div/div[1]/div/div/div[1]/div[3]/div[2]/div[2]/div[2]/div[1]";
        
        private static readonly string HAVE_AN_ACCOUNT ="/html/body/div[1]/div/div[1]/div/div/div[1]/div[3]/div[2]/div[2]/div[2]/div[6]";

        private static readonly string PLAN_LEARN = "/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/div/div/h1";
        
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        
        public LoginPage Navigate()
                 {
                     _driver.Navigate().GoToUrl(_url);
                     //HAVE_AN_ACCOUNT
                     try
                     {
                         WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromMilliseconds(50)); 
                         if (wait.Until(d => _driver.FindElements(By.XPath(HAVE_AN_ACCOUNT)).Count>0))
                         {
                             _have_an_account.Click();
                         }
                     }
                     catch (WebDriverTimeoutException e)
                     {
                     }
                     return this;
                 }
        
        public LoginPage FillUser(User user)
        {
            _emailInput.SendKeys(user.Email);
            _passwordInput.SendKeys(user.Password);
            return this;
        }

        public HomePage Submit()
        {
            _submitButton.Click();
            
            if (ElementHelper.HasElementText(_driver, By.XPath(EMAIL_OR_PASSWORD_INCORRECT), TimeSpan.FromMilliseconds(50)))
            {
                throw new TextException("Password or email is empty");
            }
            
            if (ElementHelper.HasElement(_driver, By.XPath(PLAN_LEARN), TimeSpan.FromMilliseconds(50)))
            {
                return new HomePage(_driver);
            }
            
            return null;
        }
        
        public string GetPageName()
        {
            return "Lingualeo — английский язык онлайн";
        }

        public bool AreEqual()
        {
            return _driver.Title == GetPageName();
        }
    }
}