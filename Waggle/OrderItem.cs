using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Waggle.Biz
{
    public class OrderItem
    { 

        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            this.OrderItemId = orderItemId;
        }

        public int OrderItemId { get; private set; }

        public int OrderQuantity { get; set; }

        public int ProductId { get; set; }


        //nullable to make sure that price is set
        public decimal? PurchasePrice { get; set; }


        /// <summary>
        ///  Retrieve customer by OrderItem...
        /// </summary>
        /// <param name="orderItemID"></param>
        /// <returns></returns>
        public OrderItem Retrieve(int orderItemId)
        {
            //code that retrieves selected customer
            return new OrderItem();
        }

        /// <summary>
        ///  Retrieve List of order items...
        /// </summary>
        /// <returns></returns>
        public List<OrderItem> Retrieve()
        {
            //code that retrieves selected customer
            return new List<OrderItem>();
        }

        /// <summary>
        /// Save customer information...    
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            //add to code later...
            return true;
        }

        public bool Validate()
        {
            var isValid = true;

            if (OrderQuantity <= 0) isValid = false;
            if (ProductId <=0) isValid = false;
            if (PurchasePrice == null) isValid = false;

            return isValid;


        }


    }


}
