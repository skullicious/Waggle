using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waggle.Biz
{
    public class AddressRepository
    {
        //retrieve single address
        public Address Retrieve(int addressId)
        {
            //create instance of address class and pass in ID
            Address address = new Address(addressId);

            //Placeholder for data access!!!

            //Temp hardcode for testing

            if (addressId == 1)
            {
                address.StreetLine1 = "1 Sunley Gardens";
                address.StreetLine1 = "Perivale";
                address.City = "Middlesex";
                address.Country = "United Kingdom";
                address.PostalCode = "UB6 7PF";
            }
            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId(int customerId)

        {
            //Code to retrieve addresses for customer

            //temp hardcode data for testing purposes

            var addressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "12 Catherine Howard Close",
                StreetLine2 = "",
                City = "Thetford",
                State = "Norfolk",
                Country = "United Kingdom",
                PostalCode = "IP24 1TQ"
            };
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 1,
                StreetLine1 = "12 Catherine Howard Close",
                StreetLine2 = "",
                City = "Thetford",
                State = "Norfolk",
                Country = "United Kingdom",
                PostalCode = "IP24 1TQ"
            };
            addressList.Add(address);

           

            return addressList;

        }


        public IEnumerable<Address> RetrieveByVendorId(int vendorId)

        {
            //Code to retrieve addresses for customer

            //temp hardcode data for testing purposes

            var addressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType = 2,
                StreetLine1 = "Vendorville",
                StreetLine2 = "",
                City = "Manhattan",
                State = "New York",
                Country = "USA",
                PostalCode = "NYC 123"
            };
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "SupplyLand",
                StreetLine2 = "",
                City = "Rajneesh",
                State = "Oregon",
                Country = "OGN",
                PostalCode = "OGN 456"
            };
            addressList.Add(address);



            return addressList;

        }



    }
}
