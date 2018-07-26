using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waggle.Biz
{
    public class OrderRepository
    {
        /// <summary>
        ///  Retrieve order by ID...
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public Order Retrieve (int OrderId)
        {
            //Test code to create and retrieve order
            Order order = new Order(OrderId);

            //Hard code values for test order object

            if (OrderId == 3)

            {

                order.OrderDate = DateTimeOffset.Now;
             
            }


            //code that retrieves selected order
            return order;
        }

        /// <summary>
        ///  Retrieve display order information...
        /// </summary>
        /// <returns></returns>
        /// 
        public OrderDisplay RetrieveOrderDisplay(int orderId)
        {
            OrderDisplay orderDisplay = new OrderDisplay();

            //Placeholder for real data access

            if (orderId == 10)
            {
                orderDisplay.FirstName = "Damien";
                orderDisplay.LastName = "Sweeney";
                orderDisplay.OrderDate = new DateTimeOffset(2018, 6, 10, 0, 0, 0, new TimeSpan(-6, 0, 0));
                orderDisplay.ShippingAddress = new Address()
                {
                    AddressType = 1,
                    StreetLine1 = "12 Catherine Howard Close",
                    StreetLine2 = "",
                    City = "Thetford",
                    State = "Norfolk",
                    Country = "United Kingdom",
                    PostalCode = "IP24 1TQ"
                };

            }

            orderDisplay.orderDisplayItemList = new List<OrderDisplayItem>();

            //code placeholder for order item retrieval

            // temp hard coded item data

            if (orderId ==10)
            {
                var orderDisplayItem = new OrderDisplayItem()
                {
                    ProductName = "Butt Butter Chamois Cream",
                    PurchasePrice = 20.00m,
                    OrderQuantity = 5
                };
                orderDisplay.orderDisplayItemList.Add(orderDisplayItem);

                orderDisplayItem = new OrderDisplayItem()
                {
                    ProductName = "Wiggle Electrolytes",
                    PurchasePrice = 2.00m,
                    OrderQuantity = 12
                };
                orderDisplay.orderDisplayItemList.Add(orderDisplayItem);
            }
            return orderDisplay;

        }
        /// <summary>
        ///  Retrieve List of orders...
        /// </summary>
        /// <returns></returns>
        public List<Order> Retrieve()
        {
            //code that retrieves selected order
            return new List<Order>();
        }

        /// <summary>
        /// Save order information...    
        /// </summary>
        /// <returns></returns>
        public bool Save(Order order)
        {
            //add order save code later...
            return true;
        }

    }
}
