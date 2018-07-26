using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waggle.Biz
{
    public class VendorRepository

    {

        //declare address repository as part of collaborative class
        private AddressRepository addressRepository { get; set; }

        //When constructor fires a reference to address repository is established

        public VendorRepository()
        {
            addressRepository = new AddressRepository();
        }




        /// <summary>
        /// Rerieve vendor by ID...
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public Vendor Retrieve(int vendorId)
        {
            //Test code to create and retrieve vendor
            Vendor vendor = new Vendor(vendorId);
            vendor.AddressList = addressRepository.RetrieveByVendorId(vendorId).ToList();

            //Hard code values for vendor test object

            if (vendorId == 5)

            {
                vendor.CompanyName = "Vendor Company";
                vendor.EmailAddress = "testvendor@testvendor.com";
                
                
            }


            return vendor;
        }
    
    /// <summary>
    ///Return list of vendors..
    /// </summary>
    /// <returns></returns>
    public List<Vendor>Retrieve()
    {
        return new List<Vendor>();
    }

    }

}