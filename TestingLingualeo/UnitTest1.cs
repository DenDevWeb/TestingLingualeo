using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using TestingLingualeo.Exception;
using TestingLingualeo.Helpers;
using TestingLingualeo.Models;
using TestingLingualeo.Pages;

using NUnit.Framework;

namespace TestingLingualeo
{
    public class Tests
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver("D:\\TestingLingualeo\\TestingLingualeo\\bin\\Debug\\netcoreapp3.0\\");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
        
        [Test]
        public void FailedLogin()
        {
            LoginPage loginPage = new LoginPage(_driver);
            
            //неправильный mail
            User user = User.GetRandomUser();
            user.Email = "test";
            loginPage.Navigate().FillUser(user).Submit();
            Assert.True(loginPage.AreEqual());
            
            //неправильный пароль
            user = User.GetValidUserForLogin();
            user.Password = "";
            try
            {
                loginPage.Navigate().FillUser(user).Submit();
            }
            catch (TextException e)
            {
                Assert.AreEqual("Password or email is empty",e.Message);
            }

        }
        
        [Test]
        public void SuccessLogin()
        {
            LoginPage loginPage = new LoginPage(_driver);

            User user = User.GetValidUserForLogin();
            HomePage homePage = loginPage.Navigate().FillUser(user).Submit();
                     
            Assert.True(homePage.AreEqual());
        }
        
        [Test]
        public void FailedAvatar()
        {
            LoginPage loginPage = new LoginPage(_driver);
         
            //user.Email = "test@test.ru";
            User user = User.GetValidUserForLogin();
            UserProfile userProfile = UserProfile.GetValidUserForProfile();
            try
            {
                loginPage.Navigate().FillUser(user).Submit().ToProfile().Navigate().GoToEditProfile().LoadAvatar(userProfile);
            }
            catch (TextException e)
            {
                Assert.AreEqual("The file is too large",e.Message);
            }
                     
        }
        
        [Test]
        public void SuccessUserProfile()
        {
            LoginPage loginPage = new LoginPage(_driver);
         
            //user.Email = "test@test.ru";
            User userLogin = User.GetValidUserForLogin();
            UserProfile userProfile = UserProfile.GetValidUserForProfile();
            ProfilePage result = loginPage.Navigate().FillUser(userLogin).Submit().ToProfile().Navigate().GoToEditProfile().FillUser(userProfile).GoToSaveProfile().GoToEditProfile().Submit(userProfile);
            Assert.NotNull(result);
        }
        
        [Test]
        public void FailedTranslationInTrainingWordToTranslation()
        {
            LoginPage loginPage = new LoginPage(_driver);
         
            //user.Email = "test@test.ru";
            User userLogin = User.GetValidUserForLogin();
            
            try
            {
                loginPage.Navigate().FillUser(userLogin).Submit().ToTraining().Navigate().GoToWord_Translation().Submit();
            }
            catch (TextException e)
            {
                Assert.AreEqual("The translation is incorrect",e.Message);
            }
        }
        [Test]
        public void SuccessTransitionToTheAppStore()
        {
            LoginPage loginPage = new LoginPage(_driver);
         
            User userLogin = User.GetValidUserForLogin();
            string result = loginPage.Navigate().FillUser(userLogin).Submit().GoToOurBlog();
            
            Assert.AreEqual(result, "Английский язык онлайн - Lingualeo Блог");
        }
    }
}