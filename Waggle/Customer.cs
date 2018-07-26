using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waggle.cmn;

namespace Waggle.Biz
{
    public class Customer:EntityBase,ILoggable
    {
        public Customer()
            :this(0)
        {

        }

        public Customer(int customerId)
        {
            this.CustomerId = customerId;
            AddressList = new List<Address>();
        }


        //change to an emum maybe?
        public int CustomerType { get; set; }

        public List<Address>AddressList { get; set; }

        //static demo.. remove?
        public static int InstanceCount { get; set; }

        private string _lastName;   

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        //Private setter to allow DB to set unique ID
        public int CustomerId { get; private set; }

        public string FullName
        {
            get
            {
                // sets fullname to lastname to begin building name string..
                string fullName = LastName;

                // if we have a first name proceed into code block..
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    // if we have a fullname/lastname, add a comma to the end of it..
                    if (!string.IsNullOrWhiteSpace(fullName))
                    { fullName += ", "; }
                    // then add the first name after the comma
                    fullName += FirstName;
                }
                // then return fullname whether it is blank or constructed by the above code.
                return fullName;
            }
            
        }



        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;


        }

        public override string ToString()
        {
            return FullName;
        }

        public string Log()
        {
            var logString = this.CustomerId + ": " +
                            this.FullName + " " +
                            "Email: " + this.EmailAddress + " " +
                            "Status: " + this.EntityState.ToString();
            return logString;

        }
    }
}
