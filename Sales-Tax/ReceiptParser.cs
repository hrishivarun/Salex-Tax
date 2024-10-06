using System.Text.RegularExpressions;
using Classes;

namespace Parser;

// interface Parser
// {
//   public static List<Order> ParseInput(string input);
//   public static bool IsValidItemString(string inputLine);

// };

class ReceiptParser
{
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
            PurchasedItem item = new PurchasedItem(itemString);
            orderedItems.Add(item);
        }
        index++;
    }
    return new(orderedItems);
  }

  public static string GetOutput(Order order)
  {
    string output = string.Empty;

    output += $"OUTPUT:\n";
    output += $"{order.GetReceipt()}";

    return output;
  }

  public static bool IsValidItemString(string inputLine)
  {
    //regex to check if the string matched format for item details, as provided in sample input`
    string pattern = @"^\d+[a-zA-Z\s]*\s*(imported\s+)?[a-zA-Z\s]+\s*\d+(\.\d{2})?$";
    return Regex.IsMatch(inputLine, pattern);
  }
}