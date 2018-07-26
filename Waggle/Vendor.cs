using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waggle.Biz
{
    public class Vendor
    {
        public Vendor()
            : this(0)
        {

        }

        public Vendor(int VendorId)
        {
            this.VendorId = VendorId;
            AddressList = new List<Address>();
        }




        //private setter to allow db to set unique ID
        public int VendorId { get; private set; }

        public List<Address> AddressList { get; set; }

        public string CompanyName { get; set; }

        public string EmailAddress { get; set; }

        //   public enum IncludeAddress { Yes, No};
        // public enum SendCopy { Yes,No}


        public override string ToString()
        {
            return CompanyName;
        }

    }
}

