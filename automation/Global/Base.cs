using automation.Config;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation.Global
{
    public abstract class Base
    {
        #region To access Path from resource file
        public static int Browser = Int32.Parse(Resource.Browser);
        public static String ExcelPath = Resource.ExcelPath;
        public static string ScreenshotPath = Resource.ScreenshotPath;
        public static string ReportPath = Resource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion


        #region Setup
        [SetUp]
        public void Inititalise()
        {

          
            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    var options = new ChromeOptions();
                    options.AddArguments("chrome.switches", "--disable-extensions  --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    GlobalDefinitions.driver = new ChromeDriver(options);
                    break;
            }

           

            extent = new ExtentReports(ReportPath, true, DisplayOrder.OldestFirst);
            extent.LoadConfig(Resource.ReportXMLPath);
        }


        #endregion

        #region TearDown
        [TearDown]
        public void TearDown()
        {

            // Screenshot
            ///  String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            //     test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
        //    extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :           
          GlobalDefinitions.driver.Close();
        }
        #endregion
    }
}
