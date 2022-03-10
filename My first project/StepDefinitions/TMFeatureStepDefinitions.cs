using My_first_project.Pages;
using My_first_project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace My_first_project.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions :  CommonDriver
    {
        //Initialising page bjects
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tMPageObj = new TMPage();


        [Given(@"I logged into Turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();


            loginPageObj.LoginSteps(driver);
        }

        [Given(@"I Navigate to Time and material page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create the Time and material record")]
        public void WhenICreateTheTimeAndMaterialRecord()
        {
            // TM page object intialzation and definition
            
            tMPageObj.CreateTM(driver);
        }

        [Then(@"The employee record should be created successfully")]
        public void ThenTheEmployeeRecordShouldBeCreatedSuccessfully()
        {
            string newCode = tMPageObj.GetCode(driver);
            string newTypeCode = tMPageObj.GetTypeCode(driver);
            string newDescription = tMPageObj.GetDescription(driver);
            string newPrice = tMPageObj.GetPrice(driver);

            Assert.That(newCode == "Hussein22", "Actual code and expected code do not match");
            Assert.That(newTypeCode == "T", "Actual type code and expected type code do not match");
            Assert.That(newDescription == "Hussein22", "Actual description and expected description do not match");
            Assert.That(newPrice == "$12.00", "Actual price and expected price do not match");

        }

        [When(@"I update '([^']*)', '([^']*)', '([^']*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            tMPageObj.EditTM(driver, p0, p1, p2);
        }

        [Then(@"The record should have the updated '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string p0, string p1, string p2)
        {
            string editedDescription = tMPageObj.GetEditedDescription(driver);
            string editedCode = tMPageObj.GetEditedCode(driver);
            string editedPrice = tMPageObj.GetEditedPrice(driver);


            Assert.That(editedDescription == p0, "Actual description and expected description do not match");
            Assert.That(editedCode == p1, "Actual code and expected code do not match");
            Assert.That(editedPrice == p2, "Actual price and expected price do not match");
        }


    }
}
