using automation.Global;
using automation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation.Test
{
   public  class MainClass
    {
        [TestFixture]
        class Practice : Base
        {
            [Test]
            public void AddContactForm()
            {
                //Start the Contact us test
                test = extent.StartTest("Contact Us test case starts");
                ContactUs ObjContact = new ContactUs();
                ObjContact.AddContactUs();
            }

            [Test]
            public void ValidateMandatoryData()
            {
                //Start the Contact us test
                test = extent.StartTest("Mandatory validation test case starts");
                ContactUs ObjContact = new ContactUs();
                ObjContact.ValidateMandatoryFields();
                
            }
            [Test]
            public void ValidateTitle()
            {
                test = extent.StartTest("Validate title of the page test case starts");
                ContactUs ObjContact = new ContactUs();
                ObjContact.CheckPageTitle();
            }

            [Test]
            public void ValidateInvalidEmail()
            {
                test = extent.StartTest("Validate data  test case starts");
                ContactUs ObjContact = new ContactUs();
                ObjContact.ValidateInvalidData();
            }
        }

    }
}
