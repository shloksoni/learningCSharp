using System;
using System.Collections.Generic;

namespace GenericsAssignment1
{


    class Program
    {
        static void Main(string[] args)
        {
            var Products = new Dictionary<string, Product>();

            //----------------------------construct the Products Dicionary-----------------------------------------
            AddItems(Products);

            // Q1 -> Print the total number of products in the list.
            PrintTotalProducts(Products);

            //Q2 ->  Add a new product (Potato,10RS, 50, Root).
            //       And print the list of all products and a total number of products(integer). 

            Products.Add("potato", new Product("potato", 10, 50, "Root"));
            printAllProducts(Products);
            PrintTotalProducts(Products);

            //Q3 -> Print all the products of which have the type Leafy green.

            printAllLeafyGreenProducts(Products);

            // Q4 -> As all the garlic is sold out, Remove Garlic from the list 
            //      and print the total number of products that are left on the list.

            Products.Remove("garlic");
            printAllProducts(Products);
            PrintTotalProducts(Products);

            // Q5 -> If the user adds 50 cabbages to the inventory, 
            //       print the final quantity of cabbage in the inventory.

            System.Console.WriteLine($"\n\nThe total quantity of Cabbages is {  AddQuantity(Products, "cabbage", 50)}");

            //Q6 -> If a user purchases 1kg lettuce, 2 kg zucchini, 1 kg broccoli
            //      then what is the round figure that the user needs to pay?

            var TotalCost = 0.0;
            TotalCost += Products["cabbage"].Price;
            TotalCost += (Products["zucchini"].Price * 2);
            TotalCost += Products["broccoli"].Price;

            var RoundedCost = Math.Round(TotalCost);
            System.Console.WriteLine($"\n\nThe total rounded cost is { RoundedCost}");

        }

        private static int AddQuantity(Dictionary<string, Product> Products, string name, int quantity)
        {
            if (!Products.ContainsKey(name)) return -1;

            return Products[name].Quantity += quantity;

        }

        private static void printAllLeafyGreenProducts(Dictionary<string, Product> Products)
        {
            foreach (var product in Products)
            {
                if (product.Value.Type.ToLower().Equals("leafy green"))
                {
                    System.Console.WriteLine($"{product.Value.Name} ");

                }
            }
        }

        private static void printAllProducts(Dictionary<string, Product> Products)
        {
            foreach (var product in Products)
            {
                System.Console.WriteLine($"{product.Value.Name} : {product.Value.Quantity} ");
            }
        }

        private static int PrintTotalProducts(Dictionary<string, Product> Products)
        {
            int ProductCount = 0;
            foreach (var product in Products)
            {
                ProductCount += product.Value.Quantity;
            }
            System.Console.WriteLine($"The number of products are {ProductCount}");

            return ProductCount;
        }

        static void AddItems(Dictionary<string, Product> Products)
        {
            Products.Add("lettuce", new Product("lettuce", 10.5, 50, "Leafy Green"));
            Products.Add("cabbage", new Product("cabbage", 20, 100, "Cruciferous"));
            Products.Add("pumpkin", new Product("pumpkin", 30, 30, "Marrow"));
            Products.Add("cauliflower", new Product("cauliflower", 10, 25, "Cruciferous"));
            Products.Add("zucchini", new Product("zucchini", 20.5, 50, "Marrow"));
            Products.Add("yam", new Product("yam", 30, 50, "Root"));
            Products.Add("spinach", new Product("spinach", 10, 100, "Leafy Green"));
            Products.Add("broccoli", new Product("broccoli", 20.2, 75, "Cruciferous"));
            Products.Add("garlic", new Product("garlic", 30, 20, "Leafy Green"));
            Products.Add("silverbeet", new Product("silverbeet", 10, 50, "Marrow"));
        }
    }
}
