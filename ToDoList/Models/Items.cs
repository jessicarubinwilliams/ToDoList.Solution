namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; }

    public Item(string description)
    {
      Description = description;
    }
  }
}