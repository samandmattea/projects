using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.Models.Data;

namespace CapstoneV2.BLL
{
    public class MapOperations
    {
        public string ConvertAddressToUrl(ContactInfo contact)
        {
            string address = $"{contact.StreetAddress}, {contact.City}, {contact.State}";
            if (contact.Zip != null) address += $" {contact.Zip}";
            address = address.Replace(" ", "+");
            string url = "https://www.google.com/maps/embed/v1/place?q=" + address +
                         "&zoom=15&key=AIzaSyCqBmnjONAkuxwGlva581PNNi-Q2rLUYaU";
            return url;
        }
    }
}
