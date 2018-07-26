using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waggle.Biz
{
    public class CustomerRepository
    {
        //declare address repository property as part of class
        private AddressRepository addressRepository { get; set; }


        //Contstructor creates reference to address repository

        public CustomerRepository()
        {

            addressRepository = new AddressRepository();

        }


        /// <summary>
        ///  Retrieve customer by ID...
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public Customer Retrieve(int customerId)
        {
            //Test code to create and retrieve customer
            Customer customer = new Customer(customerId);            
            customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();

            //Hard code values for test customer object

            if (customerId==1)

            {
                
                customer.EmailAddress = "testuser@testtown.com";
                customer.FirstName = "test";
                customer.LastName = "user";
            }


            //code that retrieves selected customer
            return customer;
        }

        /// <summary>
        ///  Retrieve List of customers...
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrieve()
        {
            //code that retrieves selected customer
            return new List<Customer>();
        }

        /// <summary>
        /// Save customer information...    
        /// </summary>
        /// <returns></returns>
        public bool Save(Customer customer)
        {
            //add  save code later...
            return true;
        }


    }
}
