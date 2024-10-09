namespace Models;

class Order
{
  private List<PurchasedItem> Items = new List<PurchasedItem>();

  public Order(List<PurchasedItem> purchasedItems)
  {
    Items = purchasedItems;
  }

  public List<PurchasedItem> GetPurchasedItems()
  {
    return Items;
  }
};