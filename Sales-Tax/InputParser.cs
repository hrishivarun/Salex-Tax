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
  public static List<Order> ParseInput(string input)
  {
    List<Order> orderList = [];
    List<PurchasedItem> orderedItems = [];
    int index = 0;
    while(index<input.Length)
    {
        //read the input line by line
        string currLine = string.Empty;
        while(index<input.Length && input[index] != '\n' )
        {
            currLine.Append(input[index]);
            index++;
        }
        
        //check if the string has details of the ordered item 
        string itemString = string.Empty;
        if(!string.IsNullOrEmpty(currLine) && currLine.ToLower().Contains("input") && IsValidItemString(currLine))
        {
            itemString = currLine;
            PurchasedItem item = new PurchasedItem(itemString);
            orderedItems.Add(item);
        }
        else    //stash the order and clean the list of items purchased 
        {
            orderList.Add(new Order(orderedItems));
            orderedItems.Clear();
        }
    }
    return orderList;
  }

  public static string GetOutput(List<Order> orders)
  {
    string output = string.Empty;
    for (int i=0; i<orders.Count; i++)
    {
      var order = orders[i];

      output += $"Output {i}";
      output += $"{order.GetReceipt()}";
    }

    return output;
  }

  public static bool IsValidItemString(string inputLine)
  {
      string pattern = @"^\d+\s+(imported\s+)?[a-zA-Z\s]+\s\d+(\.\d{2})?$";
      return Regex.IsMatch(inputLine, pattern);
  }
}