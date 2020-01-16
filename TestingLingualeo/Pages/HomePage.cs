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
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly string _url =
            @"https://lingualeo.com/ru/";
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[4]/div/div[2]/div[1]/div[3]/a[1]")] 
        private IWebElement _our_blog_link;
        
        private static readonly string OUR_BLOG = "/html/body/div[1]/div[3]/div[1]/div[2]/div/div[1]/a[1]";
        
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver,this);
        }
        
        public HomePage Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            
            return this;
        }
        
        public ProfilePage ToProfile()
        {
            return new ProfilePage(_driver);
        }
        
        public TrainingPage ToTraining()
        {
            return new TrainingPage(_driver);
        }
        
        public string GoToOurBlog()
        {
            _our_blog_link.Click();
            string tmp3 = _driver.Title;
            if (ElementHelper.HasElement(_driver, By.XPath(OUR_BLOG), TimeSpan.FromSeconds(5.0)))
            {
                string tmp2 = _driver.Title;
                return _driver.Title;
            }

            string tmp = _driver.Title;
            return "";
        }
        
        public string GetPageName()
        {
            return "Dashboard";
        }

        public bool AreEqual()
        {
            return _driver.Title == GetPageName();
        }
    }
}