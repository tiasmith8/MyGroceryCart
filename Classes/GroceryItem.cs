using System;
using System.Collections.Generic;
using System.Text;

namespace MyGroceryCart.Classes
{
    /// <summary>
    /// Represents an item at the grocery store
    /// </summary>
    public class GroceryItem
    {
        /// <summary>
        /// The name of the grocery item
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The price of the grocery item.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Quantity of the grocery item.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Initialize an item with name, price and quantity
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public GroceryItem(string name, decimal price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Initialize a grocery item with name and price, quanity is default to 1
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public GroceryItem(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = 1;
        }

        /// <summary>
        /// Add a coupon to an item.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddCoupon(int couponPercentage)
        {
            //Update price to be original * coupon value / 100
            if (couponPercentage > 0) //Make sure value is above 0
            {
                this.Price = this.Price * (couponPercentage / 100M);
                return true;
            }

            //Coupon percentage is invalid
            return false;
        }


    }
}
