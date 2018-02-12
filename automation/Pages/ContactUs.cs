using automation.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using static automation.Global.CommonMethods;
using static automation.Global.GlobalDefinitions;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Support.PageObjects;

namespace automation.Pages
{
    class ContactUs
    {
        // Initializing the web elements 
        internal ContactUs()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }


        //Finding FirstName
        [FindsBy(How = How.XPath, Using = "//input[@id='hugeit_preview_textbox_15']")]
        private IWebElement FirstName { get; set; }

        //Finding LastName
        [FindsBy(How = How.XPath, Using = "//input[@id='hugeit_preview_textbox_14']")]
        private IWebElement LastName { get; set; }

        //Finding Email
        [FindsBy(How = How.XPath, Using = "//input[@id='hugeit_preview_textbox_20']")]
        private IWebElement Email { get; set; }

        //Finding Phone
        [FindsBy(How = How.XPath, Using = "//input[@id='hugeit_preview_textbox_19']")]
        private IWebElement Phone { get; set; }

        //Finding Subject
        [FindsBy(How = How.XPath, Using = "//input[@id='hugeit_preview_textbox_18']")]
        private IWebElement Subject { get; set; }

        //Finding Message
        [FindsBy(How = How.XPath, Using = "//textarea[@id='hugeit_preview_textbox_17']")]
        private IWebElement Message { get; set; }

        //Click submit button
        [FindsBy(How = How.XPath, Using = "//button[@id='hugeit_preview_button__submit_21']")]
        private IWebElement BtnSubmit { get; set; }


        #region Contactus
        public void AddContactUs()
        {
            try
            {
                //Populate in collection
                ExcelLib.PopulateInCollection(Base.ExcelPath, "Contact");

                //Navigate to test env
                GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
                GlobalDefinitions.wait(500);

                //Enter FirstName
                FirstName.SendKeys(ExcelLib.ReadData(2, "FirstName"));
                GlobalDefinitions.wait(1000);

                //Enter LastName
                LastName.SendKeys(ExcelLib.ReadData(2, "LastName"));
                GlobalDefinitions.wait(1000);

                //Enter Email
                Email.SendKeys(ExcelLib.ReadData(2, "Email"));
                GlobalDefinitions.wait(1000);

                //Enter Phone
                Phone.SendKeys(ExcelLib.ReadData(2, "Phone"));
                GlobalDefinitions.wait(1000);

                //Enter Subject
                Subject.SendKeys(ExcelLib.ReadData(2, "Subject"));
                GlobalDefinitions.wait(1000);

                //Enter Message
                Message.SendKeys(ExcelLib.ReadData(2, "Message"));
                GlobalDefinitions.wait(1000);

                //Click Submit button
                BtnSubmit.Click();
                GlobalDefinitions.wait(1000);
                Base.test.Log(LogStatus.Pass, "Successfully submited contact us information");

                //Adding screenshot in extendReport
                string screenShotPath = CommonMethods.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Contact us registration");
                Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));
            }
            catch(Exception e)
            {
                   Base.test.Log(LogStatus.Fail, "Test fail");
                   Base.test.Log(LogStatus.Info, e.Message + ">>Fail to submit contact us ");
            }


        }


        #endregion

        #region CheckingValidation
        public void ValidateMandatoryFields()
        {
            //Populate in collection
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Validate_contact");

            //Navigate to test env
            GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            GlobalDefinitions.wait(500);

           
            if (GlobalDefinitions.isDialogPresent(GlobalDefinitions.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue")))
                Console.WriteLine("First Name is mandatory field");

            if (GlobalDefinitions.isDialogPresent(GlobalDefinitions.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue")))
                Console.WriteLine("Last Name is mandatory field");

            if (GlobalDefinitions.isDialogPresent(GlobalDefinitions.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue")))
                Console.WriteLine("Email is mandatory field");

            if (GlobalDefinitions.isDialogPresent(GlobalDefinitions.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue")))
                Console.WriteLine("Email is mandatory field");
            else
                Console.WriteLine("Elements not present");

            //Report generating with screenshot
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "mandatory field checking");
            string screenShotPath = CommonMethods.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Mandatory field");
            // test.Log(LogStatus.Fail, stackTrace + errorMessage);
            Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));
        }
        #endregion

        #region CheckpageTitle
        public void CheckPageTitle()
        {
            //Populate in collection
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Validate_contact");

            //Navigate to test env
            GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            GlobalDefinitions.wait(500);

            String actualTitle = GlobalDefinitions.driver.Title;
            String expectedTitle = "Contact Us Practice Form - QA Automation, NewZealandQA Automation, NewZealand";
                     
            
            if (actualTitle.Equals(expectedTitle))
               Console.WriteLine("Title Matched");
            else
                Console.WriteLine("Title didn't match");
        }
        #endregion

        #region ValidateInvalidData
        public void ValidateInvalidData()
        {
            //Populate in collection
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Validate_contact");

            //Navigate to test env
            GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            GlobalDefinitions.wait(500);

            Email.SendKeys("bincy");
            GlobalDefinitions.wait(1000);

            Phone.SendKeys("343434");
            GlobalDefinitions.wait(1000);

            if (GlobalDefinitions.isDialogPresent(GlobalDefinitions.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "LocatorValue")))
            { 
                Console.WriteLine("Incorrect Email");
            //Report generating with screenshot
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Incorrect Email");
            string screenShotPath = CommonMethods.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "InvalidData");
            // test.Log(LogStatus.Fail, stackTrace + errorMessage);
            Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));
        }
                
            else
                Console.WriteLine("Elements not present");
        }
        #endregion

    }
}
