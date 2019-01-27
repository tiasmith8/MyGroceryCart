using System;
using System.Collections.Generic;
using System.Text;

namespace MyGroceryCart.Classes
{
    public class GroceryCart
    {
        /// <summary>
        /// Total of all items in the cart.
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Number of items in the cart.
        /// </summary>
        public int TotalNumberOfItems { get; private set; }

        /// <summary>
        /// List containing all added grocery items.
        /// </summary>
        private List<GroceryItem> groceryItems = new List<GroceryItem>();
        public List<GroceryItem> GroceryItems { get; private set; }

        /// <summary>
        /// Create new cart object.
        /// </summary>
        public GroceryCart()
        {
            this.TotalPrice = 0;
            this.TotalNumberOfItems = 0;
            this.GroceryItems = groceryItems;
        }

        /// <summary>
        /// Adds a new item to the grocery cart.
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToCart(GroceryItem item)
        {
            this.GroceryItems.Add(item);
            this.TotalPrice += (item.Price * item.Quantity);
            this.TotalNumberOfItems += item.Quantity;
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
                this.TotalNumberOfItems -= item.Quantity;
                this.TotalPrice -= (item.Price * item.Quantity);
                return GroceryItems.Remove(item);
            }

            return false;
        }

        public decimal GetTotal()
        {
            return this.TotalPrice;
        }
    }
}
