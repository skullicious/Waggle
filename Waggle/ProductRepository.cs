using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waggle.cmn;


namespace Waggle.Biz
{
    public class ProductRepository
    {


        /// <summary>
        ///  Retrieve product by ID...
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product Retrieve(int productId)
        {
                   
            //Test code to create and retrieve product
            Product product = new Product(productId);

            //Hard code values for test product object

            if (productId == 2)

            {

                product.ProductName = "ultegra di-2 groupset";
                product.ProductDescription = "groupset";
                product.CurrentPrice = 800.00M;
            }

            else

            {

                //SQL Connection code
                //Create SQL Query to return an product based on it's primary key

                string sqlQuery = String.Format("select * from Product where ProductId={0}", productId);

                //Create and open connection to SQL server
                SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                //Load into product object the returned row from database
                if (dataReader.HasRows)
                {
                    Console.WriteLine("Retrieving Item");

                    while (dataReader.Read())
                    {
                        // DATAREADER RETURNS ODD FORMATTING IN DEBUG??                                     
                                         
                        product.ProductName = dataReader["ProductName"].ToString().TrimEnd().MakeAlphaNumericWithHyphenOnly();
                        product.ProductDescription = dataReader["ProductDescription"].ToString().TrimEnd().MakeAlphaNumericWithHyphenOnly();


                        //Entitystate SQL value is assigned to string
                        string entityState = (string)dataReader["EntityState"];

                        //Convert string value of entity state to the EntityState enum.
                        EntityStateOption productForEntityState = (EntityStateOption)Enum.Parse(typeof(EntityStateOption), entityState);
                        product.EntityState = productForEntityState;

                        Console.WriteLine(product.EntityState);
                    }

                    //Tidy up connection TEST
                    command.Dispose();
                    connection.Close();
                    connection.Dispose();


                }


            }
            //code that retrieves selected product
            return product;
        }






        /// <summary>
        ///  Retrieve List of products...
        /// </summary>
        /// <returns></returns>
        public List<Product> Retrieve()
        {
            //code that retrieves selected customer

            //create list to store results
            List<Product> result = new List<Product>();

            //Create SQL query to return all products
            string sqlQuery = String.Format("select * from Product");

            //Create and open connection to SQL server
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader to store returned table in memory
            SqlDataReader dataReader = command.ExecuteReader();

            //clean environment
            Product product = null;

            //load retrieved rows into result object
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {

                    //Create product
                    product = new Product();

                    //Populate product
                    product.ProductName = dataReader["ProductName"].ToString().TrimEnd().MakeAlphaNumericWithHyphenOnly();
                    product.ProductDescription = dataReader["ProductDescription"].ToString().TrimEnd().MakeAlphaNumericWithHyphenOnly();

                    //Entitystate SQL value is assigned to string
                    string entityState = (string)dataReader["EntityState"];

                    //Convert string value of entity state to the EntityState enum.
                    EntityStateOption productForEntityState = (EntityStateOption)Enum.Parse(typeof(EntityStateOption), entityState);
                    product.EntityState = productForEntityState;

                    Console.WriteLine(product.EntityState);
                //  product.EntityState = dataReader["EntityState"].ToString();
                //  product.ProductCode = dataReader["ProductCode"].ToString().MakeAlphaNumericWithHyphenOnly();
                    
                    
                    //Add object to result list
                    result.Add(product);
                }

                //Tidy up connection TEST
                command.Dispose();
                connection.Close();
                connection.Dispose();


            }

            return result;
        }

        /// <summary>
        /// Save product information...    
        /// </summary>
        /// <returns></returns>
        public bool Save(Product product)
        {

            var success = true;

            if (product.HasChanges && product.IsValid)
            {
                if (product.IsNew)
                {
                    //Call SQL stored procedure
                    //Test Code Below
                    InsertNewProduct(product);
                }
                else
                {
                    //Change product or set to inactive? also  used as delete.                    
                    UpdateExistingProduct(product);
                }
            
            }
           
            return success;
        }


        /// <summary>
        ///  Inserts new product using SQL connection
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        // public int InsertNewProduct(Product product)        


        public string InsertNewProduct(Product product)
            
        {
            //create SQL query
            string InsertSqlQuery = string.Format("Insert into Product (ProductName,ProductDescription,EntityState,Category,SequenceNumber,ProductCode) Values('{0}','{1}','{2}','{3}','{4}','{5}');" + "Select @@Identity"
                , product.ProductName, product.ProductDescription, product.EntityState, product.Category, product.SequenceNumber, product.ProductCode);

            //Create and open connection to SQL Server           
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);   
            
            connection.Open();

            //Create a command object
            SqlCommand command = new SqlCommand(InsertSqlQuery, connection);

            //Execute command object and return new  ID        
           string newProductId = command.ExecuteScalar().ToString();


            //Tidy up connection
            command.Dispose();
            connection.Close();
            connection.Dispose();

            //set return value
            Console.WriteLine(newProductId);
            return newProductId;
            

        }


        public string UpdateExistingProduct(Product product)

        {


            //create SQL query
            string UpdateSqlQuery = string.Format("Update Product SET ProductName='{0}',ProductDescription='{1}',EntityState='{2}' Where ProductId = {3};", product.ProductName, product.ProductDescription, product.EntityState, product.ProductId);

            //Create and open connection to SQL Server           
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);

            connection.Open();

            //Create a command object
            SqlCommand command = null;

            command = new SqlCommand(UpdateSqlQuery, connection);

            command.ExecuteScalar();



            Console.WriteLine(UpdateSqlQuery);

            //  SqlCommand command = new SqlCommand(UpdateSqlQuery, connection);

            string productId = product.ProductId.ToString();

            //Tidy up connection
            command.Dispose();
            connection.Close();
            connection.Dispose();

            //set return value

            return productId;
        }


    }


    
}
