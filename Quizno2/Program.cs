using System;
using System.Collections.Generic;

namespace OrderingSystem
{
    class Program
    {
        static List<(string item, double price)> orderList = new List<(string, double)>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Ordering Application");
                Console.WriteLine("1. Add Item to Order");
                Console.WriteLine("2. View Order Summary");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddItemToOrder();
                            break;
                        case 2:
                            ViewOrderSummary();
                            break;
                        case 3:
                            PlaceOrder();
                            break;
                        case 4:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }

        static void AddItemToOrder()
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            double itemPrice;
            while (true)
            {
                Console.Write("Enter item price: ");
                if (double.TryParse(Console.ReadLine(), out itemPrice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a valid number.");
                }
            }

            orderList.Add((itemName, itemPrice));
            Console.WriteLine("Item added to order.");
        }

        static void ViewOrderSummary()
        {
            Console.WriteLine("Order Summary:");
            foreach (var item in orderList)
            {
                Console.WriteLine($"Item: {item.item}, Price: {item.price}");
            }
        }

        static void PlaceOrder()
        {
            double totalPrice = 0;
            foreach (var item in orderList)
            {
                totalPrice += item.price;
            }

            Console.WriteLine($"Total Price of Order: {totalPrice}");

            // Clear the order list
            orderList.Clear();

            Console.WriteLine("Order placed. Order list cleared.");
        }
    }
}
