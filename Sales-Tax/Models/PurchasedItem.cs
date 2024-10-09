
using System.Globalization;

namespace Models;
class PurchasedItem
{
  public static List<string> ExemptedItems = new List<string>
  {
    "book", "food", "medicine"             // add names of item, that you want to be sales tax free
  };

  public static Dictionary<string, List<string>> ExemptedItemNames = new Dictionary<string, List<string>>
  {
    { "book", new List<string>{"book"} },
    { "food", new List<string>{ "chocolate", "food" } },
    { "medicine", new List<string>{ "pill", "medicine" } }
  };

  private string Name { get; set; } = string.Empty;
  private double Price { get; set; } = 0;
  private int Count { get; set; } = 0;
  private bool Imported { get; set; } = false;
  private double TotalTax { get; set; } = 0;
  private double TotalCost { get; set; } = 0;

  public PurchasedItem(string name, double price, int count, bool imported)
  {
    Name = name;
    Price = price;
    Count = count;
    Imported = imported;

    TotalTax = CalculateTax();
    TotalCost = CalculateTotalCost();
  }

  //=====================================================================================
  //=====================================================================================
  #region ItemDetails
  //=====================================================================================
  //=====================================================================================
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
  private double CalculateTotalCost()
  {
    return Math.Round((Price*Count) + TotalTax, Constants.RoundingConst);
  }
  //=====================================================================================
  //=====================================================================================
  #endregion
  //=====================================================================================
  //=====================================================================================

  
  //=====================================================================================
  //=====================================================================================
  #region TaxCalc
  //=====================================================================================
  //=====================================================================================
  private double CalculateSalesTax()
  {
    bool isExempted = false;
    foreach(var (entry, value) in ExemptedItemNames)
    {
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
  private double CalculateImportTax()
  {
    if(!Imported)
      return 0;
    double importTaxPerPiece = (Price * Constants.ImportTaxPercentage) / 100;
    return importTaxPerPiece*Count;
  }
  private double CalculateTax()
  {
    return CalculateSalesTax()+CalculateImportTax();
  }
  //=====================================================================================
  //=====================================================================================
  #endregion
  //=====================================================================================
  //=====================================================================================
};