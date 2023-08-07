namespace MightyTextAdventure.Data.Items;

public class Inventory
{
  private readonly List<Item> _items;

  public Inventory(List<Item> items)
  {
    _items = new List<Item>();
    foreach (var item in items)
    {
      _items.Add(item);
    }
  }

  public Inventory()
  {
    _items = new List<Item>();
  }

  public Inventory(Item item)
  {
    _items = new List<Item> { item };
  }

  public void AddItem(Item item)
  {
    _items.Add(item);
  }

  public void RemoveItem(Item item)
  {
    _items.Remove(item);
  }
}