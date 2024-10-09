using System.Globalization;
using System.Text.RegularExpressions;
using Models;

namespace Parser;

class ReceiptParser
{
  //=====================================================================================
  //=====================================================================================
  #region ParseInput
  //=====================================================================================
  //=====================================================================================
  public static Order ParseInput(string input)
  {
    List<PurchasedItem> orderedItems = [];
    int index = 0;
    while(index<input.Length)
    {
        //read the input line by line
        string currLine = string.Empty;
        while(index<input.Length && input[index] != '\n' )
        {
            currLine += $"{input[index]}";
            index++;
        }
        currLine = currLine.Trim();
        
        //check if the string has details of the ordered item 
        string itemString = string.Empty;
        if(!string.IsNullOrEmpty(currLine) && !currLine.ToLower().Contains("input") && IsValidItemString(currLine))
        {
            itemString = currLine;
            PurchasedItem item = ParseLine(itemString);
            orderedItems.Add(item);
        }
        index++;
    }
    return new(orderedItems);
  }

    private static PurchasedItem ParseLine(string line)
  {
    bool itemImported = line.Contains("imported") ? true:false;

    //Extract count of item from details string
    int intCounter=0;
    int itemCount = 0;
    while(line.ElementAt(intCounter)>=48 && line.ElementAt(intCounter)<=57)
    {
      itemCount = (itemCount*10) + line.ElementAt(intCounter)-'0';
      intCounter++;
    }

    //Extract price of item from line string
    int doubleCounter=line.Length-1;
    while (doubleCounter >= 0 && (char.IsDigit(line[doubleCounter]) || line[doubleCounter] == '.' || line[doubleCounter] == ','))
    {
        doubleCounter--;
    }
    string numberPart = line.Substring(doubleCounter + 1).Trim();
    double itemPrice = double.Parse(numberPart, CultureInfo.InvariantCulture);

    //Extract name of item from line string
    string itemName = line.Substring(intCounter, doubleCounter-intCounter+1);
    var item = new PurchasedItem(itemName, itemPrice, itemCount, itemImported);

    return item;
  }
  //=====================================================================================
  //=====================================================================================
  #endregion
  //=====================================================================================
  //=====================================================================================

  //=====================================================================================
  //=====================================================================================
  #region GetOutput
  //=====================================================================================
  //=====================================================================================
  public static string GetOutput(Order order)
  {
    string output = string.Empty;

    output += $"OUTPUT:\n";
    output += $"{GetReceipt(order)}";

    return output;
  }
  public static string GetReceipt(Order order)
  {
    string orderOutput = string.Empty;
    double totalSalesTaxes = 0;
    double totalCost = 0;
    
    List<PurchasedItem> items = order.GetPurchasedItems();
    foreach(var item in items)
    {
      //  add item's output
      orderOutput += GetItemReceipt(item);

      var itemPrice = item.GetPrice();
      var itemCount = item.GetCount();
      var totalTax = item.GetTotalTax();
      
      totalSalesTaxes += item.GetTotalTax();
      totalCost += Math.Round((itemPrice*itemCount) + totalTax, Constants.RoundingConst);
    }
    
    //add total sales tax and total cost of the order
    orderOutput += $"Sales Tax: {totalSalesTaxes}\n";
    orderOutput += $"Total: {totalCost}\n\n";
    
    return orderOutput;
  }
  public static string GetItemReceipt(PurchasedItem item)
  {
      var itemName = item.GetName();
      var itemPrice = item.GetPrice();
      var itemCount = item.GetCount();
      var totalTax = item.GetTotalTax();
      var totalPrice = Math.Round((itemPrice*itemCount) + totalTax, Constants.RoundingConst);
      
      return $"{itemCount} {itemName}: {totalPrice}\n";
  }
  //=====================================================================================
  //=====================================================================================
  #endregion
  //=====================================================================================
  //=====================================================================================

  private static bool IsValidItemString(string inputLine)
  {
    //regex to check if the string matched format for item details, as provided in sample input`
    string pattern = @"^\d+[a-zA-Z\s]*\s*(imported\s+)?[a-zA-Z\s]+\s*\d+(\.\d{2})?$";
    return Regex.IsMatch(inputLine, pattern);
  }
}