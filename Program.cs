using System;
using MyGroceryCart.Classes;

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
                Console.Write("\nEnter items as \"name price quantity\" Example: apple 3.99 1: ");

                //Read in user input
                string groceryItem = Console.ReadLine();

                //Parse the input string
                string[] parsedUserInput = groceryItem.Split(" ");

                //Create a new grocery item with parsed input
                GroceryItem newGroceryItem = new GroceryItem(parsedUserInput[0],
                    decimal.Parse(parsedUserInput[1]), int.Parse(parsedUserInput[2]));

                //Print what was entered
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You entered: {newGroceryItem.Quantity} {newGroceryItem.Name}s for the " +
                    $"price of {newGroceryItem.Price:C2}!\n");
                //Add grocery item to cart
                groceryCart.AddItemToCart(newGroceryItem);
                //Print the total for all items
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Total Items: {groceryCart.TotalNumberOfItems}. Total Price: {groceryCart.TotalPrice}");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Would you like to enter another itme? (y/n): ");
                string enterMoreItems = Console.ReadLine();
                if (enterMoreItems.ToLower().Equals("n"))
                {
                    break;
                }
            }

            Console.WriteLine("Thank you for using MyGroceryCart!");

        }
    }
}
