using System;
using MyGroceryCart.Classes;

using System.ComponentModel;

namespace MyGroceryCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to the Grocery Cart App!\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            //Create new cart
            GroceryCart groceryCart = new GroceryCart();

            //Prompt user for item inputs
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nEnter items as \"name price quantity\" Example: Apple 3.99 1: ");

                //Read in user input
                string groceryItem = Console.ReadLine();

                //Parse the input string
                string[] parsedUserInput = groceryItem.Split(" ");

                //Create a new grocery item with parsed input
                GroceryItem newGroceryItem = new GroceryItem(parsedUserInput[0],
                    decimal.Parse(parsedUserInput[1]), int.Parse(parsedUserInput[2]));

                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(newGroceryItem))
                {
                    Console.WriteLine($"{descriptor.Name}: {descriptor.GetValue(newGroceryItem)}");
                }

                return;

                //Print what was entered
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You entered: {newGroceryItem.Quantity} {newGroceryItem.Name}s for the " +
                    $"price of {newGroceryItem.Price:C2} each!\n");
                //Add grocery item to cart
                groceryCart.AddItemToCart(newGroceryItem);
                //Print the total for all items
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Total Items: {groceryCart.TotalNumberOfItems}. Total Price: {groceryCart.TotalPrice:C2}");

                //Ask user if they have a coupon
                Console.Write("Do you have a coupon for this item? (y/n): ");
                string hasCoupon = Console.ReadLine();
                if (hasCoupon.ToLower().Equals("y"))
                {
                    Console.Write($"Enter coupon amount for {newGroceryItem.Name} without %(ex: 15): ");
                    int couponAmount = int.Parse(Console.ReadLine());
                    //Call the GroceryItem.AddCoupon method on only that item
                    newGroceryItem.AddCoupon(couponAmount);
                    Console.WriteLine($"You applied a {couponAmount}% discount to {newGroceryItem.Name}");
                    Console.WriteLine($"The new price for {newGroceryItem.Name} is {newGroceryItem.Price}");
                    Console.WriteLine($"Cart total is:  {groceryCart.TotalPrice}");

                    

                }

     
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Would you like to enter another item? (y/n): ");
                string enterMoreItems = Console.ReadLine();
                if (enterMoreItems.ToLower().Equals("n"))
                {
                    break;
                }
            }

            while (true)
            {
                //Prompt user to enter discount
                Console.Write("Do you have a discount to apply? (y/n) ");
                string coupons = Console.ReadLine();

                //If they say no, exit app
                if (coupons.ToLower().Equals("y"))
                {
                    
                    //If they say yes
                    Console.Write("Enter value of discount(for 15% enter 15): ");
                    string discountValue = Console.ReadLine();

                    //Apply discount to cart total
                    groceryCart.AddDiscount(int.Parse(discountValue));
                    Console.WriteLine($"New cart total: {groceryCart.TotalPrice:C2}");
                    break;
                }
                else
                {
                    break;
                }
            }

            //Exit app
            Console.WriteLine("\nThank you for using MyGroceryCart!\n");

        }
    }
}
