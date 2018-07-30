using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Waggle.cmn;




namespace Waggle.Biz
{
    ///<summary>
    ///
    /// Managed inventory of products
    /// </summary>

    public class Product:EntityBase,ILoggable

    {
        public string ValidationMessage { get; private set; }



        public Product()
        {
            //Default Contructor for product objects
        }

        public Product(int productId)
        {
            ProductId = productId;
        }


        public Product(int productId,
                        string productName,
                        string productDescription) : this()

        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductDescription = productDescription;

        }

        
        public int ProductId { get; private set; }

        private string _ProductName;

        public string ProductName
        {
            get
            {
            return StringHandler.InsertSpaces(_ProductName);
            }
            set
            {
                Console.WriteLine(value.Length);


                if (value.Length >= 3 && value.Length <=30)
                {
                _ProductName = value;
               
                Console.WriteLine("Valid!");
                }

                else
                {
                ValidationMessage = "Product Name must be between 3 and 30 characters long...";
                Console.WriteLine("Invalid!");
                }
                   
            }
        }


        private string productDescription;
        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }               

        private DateTime? availabilityDate;      
        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public Decimal? CurrentPrice { get; set; }

     
        
        public decimal Cost { get; set; }

        public decimal CalculateRRP(decimal MarkupPercent) => this.Cost + (this.Cost * MarkupPercent / 100);

        private string Category { get; set; }

        public int SequenceNumber { get; set; }

        public string ProductCode => this.Category + "SequenceNumberPlaceHolder!!";
                       
        
        public override bool Validate()
        {
            var isValid = true;

            
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (string.IsNullOrWhiteSpace(ProductDescription)) isValid = false;

            return isValid;


        }
        

        public override string ToString()
        {
            return ProductName;
            
        }


        public string Log()
        {
            var logString = this.ProductId + ": " +
                            this.ProductName + " " +
                            "Detail: " + this.ProductDescription + " " +
                            "Status: " + this.EntityState.ToString();
            return logString;

        }

    }

      
}
