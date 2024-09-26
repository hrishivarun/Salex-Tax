namespace Classes;

class Order
{
  private List<PurchasedItem> items = new List<PurchasedItem>();

  public Order(List<PurchasedItem> purchasedItems)
  {
    items = purchasedItems;
  }

  public string GetReceipt()
  {
    string orderOutput = string.Empty;
    double totalSalesTaxes = 0;
    double totalCost = 0;
    Console.WriteLine("\nReceipt:-\n");
    for(int i=0; i<items.Count; i++)
    {
      var item = items[i];
    }
    foreach(var item in items)
    {
      var itemName = item.GetName();
      var itemPrice = item.GetPrice();
      var itemCount = item.GetCount();
      var itemImported = item.GetImportStatus();
      var totalTax = item.GetTotalTax();
      var totalPrice = Math.Round((itemPrice*itemCount) + totalTax, Constants.RoundingConst);
      
      orderOutput += $"{itemCount} {itemName}: {totalPrice}\n";

      totalSalesTaxes += totalTax;
      totalCost += totalPrice;
    }
    
    orderOutput += $"Sales Tax: {totalSalesTaxes}\n";
    orderOutput += $"Total: {totalCost}\n\n";
    
    return orderOutput;
  }

};