using System;
using System.Collections.Generic;
using System.Text;

namespace MyGroceryCart.Classes
{
    /// <summary>
    /// Represents a grocery cart.
    /// </summary>
    public class GroceryCart
    {
        private decimal totalPrice;
        /// <summary>
        /// Total of all items in the cart.
        /// </summary>
        //Returns total price for items in cart.
        //Derived property calculated with Price Property in GroceryItem
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0.0M;
                foreach(GroceryItem item in GroceryItems)
                {
                    total += ((item.Price)*item.Quantity);
                }
                return total;
            }
            set { totalPrice = value; }
        }

        /// <summary>
        /// Number of items in the cart.
        /// </summary>
        //// Derived property based on quantity in cart
        //public int TotalNumberOfItems { get; private set; }
        public int TotalNumberOfItems
        {
            get
            {
                int totalItems = 0;
                foreach(GroceryItem item in GroceryItems)
                {
                    totalItems += item.Quantity;
                }
                return totalItems;
            }
        }

        /// <summary>
        /// List containing all added grocery items.
        /// </summary>
        public List<GroceryItem> GroceryItems { get; private set; }

        /// <summary>
        /// Create new cart object.
        /// </summary>
        public GroceryCart()
        {
            this.GroceryItems = new List<GroceryItem>();
        }

        /// <summary>
        /// Adds a new item to the grocery cart.
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToCart(GroceryItem item)
        {
            this.GroceryItems.Add(item);
        }

        /// <summary>
        /// Remove an item from the cart.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool RemoveItemFromCart(GroceryItem item)
        {
            if (GroceryItems.Contains(item))
            {
                return GroceryItems.Remove(item);
            }

            return false;
        }
        /// <summary>
        /// Add a discount to cart.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddDiscount(int discountPercentage)
        {
            //Update price to be original * coupon value / 100
            if (discountPercentage > 0) //Make sure value is above 0
            {
                //Add the discount to all cart items
                foreach(GroceryItem item in GroceryItems)
                {
                    item.AddCoupon(discountPercentage);
                }

                return true;
            }

            //Coupon percentage is invalid
            return false;
        }



    }
}
