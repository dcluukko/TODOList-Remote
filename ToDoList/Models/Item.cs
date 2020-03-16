using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
  
  public Item(string description, int itemId)
    {
        Description = description;
        ItemId = itemId;
    }

   public static void ClearAll()
  {
    MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM items;";
     cmd.ExecuteNonQuery();
     conn.Close();
     if (conn != null)
     {
      conn.Dispose();
     }
  }

     public static Item Find(int searchId)
  {
    Item placeholderItem = new Item("placeholder item");
    return placeholderItem;
  }

  public static List<Item> GetAll()
  {
    List<Item> allItems = new List<Item> { };
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM items;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while (rdr.Read())
    {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
    }
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
    return allItems;
  }
  }
}