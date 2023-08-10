namespace MightyTextAdventure.Data.Items;

public class Inventory
{
  public int ItemCount => Items.Count;

  public List<Item> Items { get; }

  public Inventory(List<Item> items)
  {
    Items = new List<Item>();
    foreach (var item in items)
    {
      Items.Add(item);
    }
  }

  public Inventory()
  {
    Items = new List<Item>();
  }

  public Inventory(Item item)
  {
    Items = new List<Item> { item };
  }

  public void AddItem(Item item)
  {
    Items.Add(item);
  }

  public bool RemoveItem(Item item)
  {
    return Items.Remove(item);
  }

  public Lamp FindLamp()
  { 
      return (Lamp)Items.Find(item => item.GetType() == typeof(Lamp));
  }
}