using System.Collections.Generic;
using System;

namespace BestRestaurant.Models
{
  public class Cuisine
  {
    private int _id;
    private string _cuisineName;

    public Cuisine(string cuisineName, int id = 0)
    {
      _id = id;
      _cuisineName = cuisineName;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetCuisineName()
    {
      return _cuisineName;
    }

    public void Save()
    {
      //Save method after lunch
    }

    public static List<Cuisine> GetAllCuisines()
    {
      List<Cuisine> allCuisine = new List<Cuisine> {};

      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cuisines;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int cuisine_id = rdr.GetInt32(0);
        string cuisine_name = rdr.GetString(1);
        Cuisine newCuisine = new Cuisine(cuisine_name, cuisine_id);
        allCuisine.Add(newCuisine);
      }

      return allCuisine;
    }


  }
}
