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