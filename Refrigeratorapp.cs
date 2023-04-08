using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
                            // Vibhanshu Kaushal 
namespace Hello
{
    internal class Refrigeratorapp
    {
        static void Main(string[] args)
        {
            // Creating a new Refrigerator object
            Refrigerator fridge = new Refrigerator();
            // Loop indefinitely until the user chooses to exit
            while (true)
            {
                // Display main menu
                Console.WriteLine("Refrigerator App Main Menu");
                Console.WriteLine("1. Insert product");
                Console.WriteLine("2. Enter consumption");
                Console.WriteLine("3. Check current status");
                Console.WriteLine("4. Display purchase history");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                // Prompt the user to enter an option
                Console.WriteLine("Enter Your Option"); 
                string option = Console.ReadLine();
                // Switch statement to handle the user's choice
                switch (option)
                {
                    case "1":
                        Console.Write("Enter product name: ");
                        string product = Console.ReadLine();

                        Console.Write("Enter quantity (in kg or ltrs): ");
                        string quantity = Console.ReadLine();

                        fridge.InsertProduct(product, quantity);
                        break;

                    case "2":
                        Console.Write("Enter product name: ");
                        string product2 = Console.ReadLine();

                        Console.Write("Enter consumption (in kg or ltrs): ");
                        string consumption = Console.ReadLine();

                        fridge.EnterConsumption(product2, consumption);
                        break;

                    case "3":
                        fridge.CheckCurrentStatus();
                        break;

                    case "4":
                        fridge.DisplayPurchaseHistory();
                        break; 

                    case "5":
                        Console.WriteLine("Thank you for using Refrigerator App");
                        Thread.Sleep(1000);  
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
                Console.WriteLine(); 
            }
            
        }
    }

    public class Refrigerator
    {
        // Define a private dictionary to store the products and their quantities
        private Dictionary<string, double> products;
        private List<string> purchaseHistory;


        // Constructor for the Refrigerator class
        public Refrigerator()
        {
            products = new Dictionary<string, double>();
            purchaseHistory = new List<string>();
        }
        // Method to insert a new product into the refrigerator app
        public void InsertProduct(string product, string quantity)
        {
            double q;

            if (double.TryParse(quantity, out q))
            {
                // If the product already exists in the dictionary, add the new quantity to the existing quantity
                if (products.ContainsKey(product))
                {
                    products[product] += q;
                }
                // Otherwise, add the new product and its quantity to the dictionary
                else
                {
                    products.Add(product, q);
                }
                purchaseHistory.Add($"{product} - {quantity}");
                Console.WriteLine("Product added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid quantity entered. Please enter a valid number.");
            }
            

        }

        // Method to enter consumption of a product from the refrigerator
        public void EnterConsumption(string product, string consumption)
        {
            double c;

            if (double.TryParse(consumption, out c))
            {
                // Check if the product exists in the dictionary
                if (products.ContainsKey(product))
                {
                    // Check if the current quantity for the product is greater than or equal to the consumption
                    if (products[product] >= c)
                    {
                        // If it is, subtract the consumption from the current quantity for the product
                        products[product] -= c;
                        Console.WriteLine("Consumption entered successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient quantity of product. Please enter a valid consumption value.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found in the refrigerator.");
                }
            }
            else
            {
                Console.WriteLine("Invalid consumption entered. Please enter a valid number.");
            }
        }
        // Method to display the current items present in the refrigerator
        public void CheckCurrentStatus()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products found in the refrigerator.");
            }
            else
            {
                Console.WriteLine("Current status of products in the refrigerator:");
                foreach (KeyValuePair<string, double> kvp in products)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
        // Method to display the purchase history of the refrigerator
        public void DisplayPurchaseHistory()
        {
            if (purchaseHistory.Count == 0)
            {
                Console.WriteLine("No purchase history found.");
            }
            else
            {
                Console.WriteLine("Purchase history:");
                foreach (string purchase in purchaseHistory)
                {
                    Console.WriteLine(purchase);
                }
            }
        }
    }
}
