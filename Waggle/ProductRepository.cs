﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                    Console.WriteLine("WE GOT ROWS!");

                    while (dataReader.Read())
                    {
                        // DATAREADER RETURNS ODD FORMATTING! INVESTIGATE AND TIDY!


                     //   product.ProductId = Convert.ToInt32(datareader["ProductId"]);
                        product.ProductName = dataReader["ProductName"].ToString().TrimEnd();
                        product.ProductDescription = dataReader["ProductDescription"].ToString();
                        


                        Console.WriteLine("DATAREADER BE READING!"); 
                        Console.WriteLine(product.ProductName);
                        Console.WriteLine(product.ProductDescription);
                    }

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
                    product.ProductName = dataReader["ProductName"].ToString().TrimEnd();
                    product.ProductDescription = dataReader["ProductDescription"].ToString();

                    //Add object to result list
                    result.Add(product);
                }


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
                    //Call update stored procedure//also  used as delete.




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

            //switch this back to int and figure out casting..


        public string InsertNewProduct(Product product)
            
        {
            //create SQL query
            string sqlQuery = string.Format("Insert into Product (ProductName,ProductDescription) Values('{0}','{1}');" + "Select @@Identity", product.ProductName, product.ProductDescription);

            //Create and open connection to SQL Server           
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);   
            
            connection.Open();

            //Create a command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Execute command object and return new  ID
            // int newProductId = Convert.ToInt32((decimal)command.ExecuteScalar());
            //   string newProductId = command.ToString();
            string newProductId = command.ExecuteScalar().ToString();


            //Tidy up connection
            command.Dispose();
            connection.Close();
            connection.Dispose();

            //set return value
            Console.WriteLine(newProductId);
            return newProductId;
            

        }
        

    }
}