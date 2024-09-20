// // See https://aka.ms/new-console-template for more information
using Classes;

List<Order> orders = new List<Order>();

bool continueTakingInput = true;
Console.WriteLine("\n\nWelcome to our Receipt Controller!!!\n\n");
while (continueTakingInput)
{
    List<PurchasedItem> items = new List<PurchasedItem>();

    Console.WriteLine("Please items and their details!\n");
    bool takeAnotherInput = true;

    while (takeAnotherInput)
    {
        Console.WriteLine("\nEnter item details: \n");
        string details = Console.ReadLine().Trim();
        PurchasedItem item = new PurchasedItem(details).ParseDetailString();
        items.Add(item);

        Console.WriteLine("\nAdd more items?(y/n)---(Default: y) : ");
        string addMoreItems = Console.ReadLine().Trim().ToLower();
        if (!addMoreItems.Equals("") && !addMoreItems.Equals("y"))
        {
            takeAnotherInput = false;
        }
    }
    orders.Add(new Order(items));

    Console.WriteLine("\n\nAdd more orders?(y/n)---(Default: y) : ");
    string addMoreOrders = (Console.ReadLine()).Trim().ToLower();
    if (!addMoreOrders.Equals("") && !addMoreOrders.Equals("y"))
    {
        continueTakingInput = false;
    }
}

Console.WriteLine("\n\n\nReceipts: - \n");
foreach (var order in orders)
{
    order.PrintReceipt();
}






// using System;
// using System.Collections.Generic;

// namespace Goods
// {
//     public class PurchasedItem
//     {
//         public string Name { get; private set; }
//         public bool IsImported { get; private set; }
//         public double Price { get; private set; }
//         public int Count { get; private set; }
//         public double SalesTax { get; private set; }
//         public double ImportTax { get; private set; }

//         public PurchasedItem(string details)
//         {
//             ParseDetails(details);
//         }

//         // Parse input item details from the string
//         private void ParseDetails(string details)
//         {
//             string[] parts = details.Split(" at ");
//             string[] nameParts = parts[0].Split(' ');
            
//             Count = int.Parse(nameParts[0]);
//             Name = string.Join(' ', nameParts, 1, nameParts.Length - 1);
//             IsImported = Name.Contains("imported");
//             Price = double.Parse(parts[1]);
//         }

//         // Calculates and returns total tax (rounded)
//         public double GetTotalTax()
//         {
//             return Math.Round(SalesTax + ImportTax, 2);
//         }

//         public void CalculateSalesTax(bool isExempt)
//         {
//             if (!isExempt)
//             {
//                 SalesTax = RoundUpToNearest0_05(Price * 0.10);
//             }
//             else
//             {
//                 SalesTax = 0;
//             }
//         }

//         public void CalculateImportTax()
//         {
//             if (IsImported)
//             {
//                 ImportTax = RoundUpToNearest0_05(Price * 0.05);
//             }
//             else
//             {
//                 ImportTax = 0;
//             }
//         }

//         private double RoundUpToNearest0_05(double tax)
//         {
//             return Math.Ceiling(tax * 20) / 20.0;
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             HashSet<string> ExemptedItems = new HashSet<string>
//             {
//                 "book", "chocolate", "pill" // Assuming some basic words for exempted categories
//             };

//             List<List<PurchasedItem>> orders = new List<List<PurchasedItem>>();

//             Console.WriteLine("\n\nWelcome to the Receipt Controller!!!\n\n");
//             bool continueTakingInput = true;

//             while (continueTakingInput)
//             {
//                 List<PurchasedItem> items = new List<PurchasedItem>();

//                 Console.WriteLine("Please enter items and their details!\n");

//                 bool takeAnotherInput = true;
//                 while (takeAnotherInput)
//                 {
//                     Console.WriteLine("\nEnter item details (e.g., 1 book at 12.49): \n");
//                     string details = Console.ReadLine().Trim();
//                     PurchasedItem item = new PurchasedItem(details);
//                     items.Add(item);

//                     Console.WriteLine("\n\nAdd more items? (y/n) (Default: y): ");
//                     string addMoreItems = Console.ReadLine().Trim().ToLower();
//                     if (!string.IsNullOrEmpty(addMoreItems) && addMoreItems == "n")
//                     {
//                         takeAnotherInput = false;
//                     }
//                 }

//                 orders.Add(items);

//                 Console.WriteLine("\n\nAdd more orders? (y/n) (Default: y): ");
//                 string addMoreOrders = Console.ReadLine().Trim().ToLower();
//                 if (!string.IsNullOrEmpty(addMoreOrders) && addMoreOrders == "n")
//                 {
//                     continueTakingInput = false;
//                 }
//             }

//             foreach (var order in orders)
//             {
//                 double totalSalesTaxes = 0;
//                 double totalCost = 0;
//                 Console.WriteLine("\n\nReceipt:-\n");

//                 foreach (var item in order)
//                 {
//                     bool isExempt = false;

//                     // Check if item is exempted
//                     foreach (var exemptItem in ExemptedItems)
//                     {
//                         if (item.Name.Contains(exemptItem))
//                         {
//                             isExempt = true;
//                             break;
//                         }
//                     }

//                     item.CalculateSalesTax(isExempt);
//                     item.CalculateImportTax();

//                     var itemName = item.Name;
//                     var itemPrice = item.Price;
//                     var itemCount = item.Count;
//                     var itemTax = item.GetTotalTax();
//                     var totalPrice = Math.Round(itemPrice * itemCount + itemTax, 2);

//                     Console.WriteLine($"{itemCount} {itemName}: {totalPrice}\n");
//                     totalSalesTaxes += itemTax;
//                     totalCost += totalPrice;
//                 }

//                 Console.WriteLine($"Sales Taxes: {Math.Round(totalSalesTaxes, 2)}");
//                 Console.WriteLine($"Total: {Math.Round(totalCost, 2)}\n\n");
//             }
//         }
//     }
// }
