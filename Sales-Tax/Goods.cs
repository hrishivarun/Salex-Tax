using System.Globalization;

namespace Classes;

class Constants
{
  public static double SalesTaxPercentage = 10;
  public static double ImportTaxPercentage = 5;
  public static int RoundingConst = 2;
};

class PurchasedItem
{
  public static List<string> ExemptedItems = new List<string>
  {
    "book", "food", "medicine"             // add names of item, that you want to be sales tax free
  };

  public static Dictionary<string, List<string>> ExemptedItemNames = new Dictionary<string, List<string>>
  {
    { "book", new List<string>{"book"} },
    { "food", new List<string>{ "chocolate" } },
    { "medicine", new List<string>{ "pill" } }
  };

  private string Name { get; set; } = string.Empty;
  private string Details { get; set; } = string.Empty;
  private double Price { get; set; } = 0;
  private int Count { get; set; } = 0;
  private bool Imported { get; set; } = false;
  private double TotalTax { get; set; } = 0;

  public PurchasedItem(string details)
  {
    Details = details;
  }
  public PurchasedItem(string name, double price, int count, bool imported)
  {
    Name = name;
    Price = price;
    Count = count;
    Imported = imported;

    CalculateTax();
  }

  public string GetName()
  {
    return Name;
  }
  public double GetPrice()
  {
    return Price;
  }
  public int GetCount()
  {
    return Count;
  }
  public bool GetImportStatus()
  {
    return Imported;
  }
  public double GetTotalTax()
  {
    return Math.Round(TotalTax, Constants.RoundingConst);
  }

  public double CalculateSalesTax()
  {
    bool isExempted = false;
    foreach(var (entry, value) in ExemptedItemNames)
    {
        // do something with entry.Value or entry.Key
        foreach(var itemName in value)
        {
          if(Name.Contains(itemName))
          {
            isExempted = true;
          }
        }
    }
    if(isExempted)
      return 0;
    
    double salesTaxPerPiece = Price * Constants.SalesTaxPercentage / 100;
    return salesTaxPerPiece*Count;
  }

  public double CalculateImportTax()
  {
    if(!Imported)
      return 0;
    double importTaxPerPiece = Price * Constants.ImportTaxPercentage / 100;
    return importTaxPerPiece*Count;
  }

  public double CalculateTax()
  {
    TotalTax = CalculateSalesTax()+CalculateImportTax();
    return TotalTax;
  }

  public PurchasedItem ParseDetailString()
  {
    bool itemImported = Details.Contains("imported") ? true:false;

    //Extract count of item from details string
    int intCounter=0;
    int itemCount = 0;
    while(Details.ElementAt(intCounter)>=48 && Details.ElementAt(intCounter)<=57)
    {
      itemCount = (itemCount*10) + Details.ElementAt(intCounter)-'0';
      intCounter++;
    }

    //Extract price of item from details string
    int doubleCounter=Details.Length-1;
    while (doubleCounter >= 0 && (char.IsDigit(Details[doubleCounter]) || Details[doubleCounter] == '.' || Details[doubleCounter] == ','))
    {
        doubleCounter--;
    }
    string numberPart = Details.Substring(doubleCounter + 1).Trim();
    double itemPrice = double.Parse(numberPart, CultureInfo.InvariantCulture);

    //Extract name of item from details string
    string itemName = Details.Substring(intCounter, doubleCounter-intCounter+1);

    return new PurchasedItem(itemName, itemPrice, itemCount, itemImported);
  }
};

class Order
{
  private List<PurchasedItem> items = new List<PurchasedItem>();

  public Order(List<PurchasedItem> purchasedItems)
  {
    items = purchasedItems;
  }

  public void PrintReceipt()
  {
    double totalSalesTaxes = 0;
    double totalCost = 0;
    Console.WriteLine("\nReceipt:-\n");
    foreach(var item in items)
    {
      var itemName = item.GetName();
      var itemPrice = item.GetPrice();
      var itemCount = item.GetCount();
      var itemImported = item.GetImportStatus();
      var totalTax = item.GetTotalTax();
      var totalPrice = Math.Round((itemPrice*itemCount) + totalTax, Constants.RoundingConst);
      
      Console.WriteLine($"{itemCount} {itemName}: {totalPrice}\n");
      totalSalesTaxes += totalTax;
      totalCost += totalPrice;
    }
    
    Console.WriteLine($"Sales Tax: {totalSalesTaxes}\n");
    Console.WriteLine($"Total: {totalCost}\n\n");
  }

};

