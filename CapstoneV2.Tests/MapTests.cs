using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.BLL;
using CapstoneV2.Models.Data;
using NUnit.Framework;

namespace CapstoneV2.Tests
{
    [TestFixture]
    public class MapTests
    {
        [Test]
        public void ConvertAddressToUrl()
        {
            var ops = new MapOperations();
            var contact = new ContactInfo
            {
                StreetAddress = "5781 St. Joseph Ave",
                City = "Stevensville",
                State = "MI",
                Zip = null
            };
            // Check that it works without a zip code
            string result = ops.ConvertAddressToUrl(contact);
            string expected =
                "https://www.google.com/maps/embed/v1/place?q=5781+St.+Joseph+Ave,+Stevensville,+MI&zoom=15&key=AIzaSyCqBmnjONAkuxwGlva581PNNi-Q2rLUYaU";
            Assert.AreEqual(expected, result);

            // Check that it works with a zip code
            contact.Zip = "49127";
            result = ops.ConvertAddressToUrl(contact);
            expected =
                "https://www.google.com/maps/embed/v1/place?q=5781+St.+Joseph+Ave,+Stevensville,+MI+49127&zoom=15&key=AIzaSyCqBmnjONAkuxwGlva581PNNi-Q2rLUYaU";
            Assert.AreEqual(expected, result);
            
        }
    }
}
