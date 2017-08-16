using System.Collections.Generic;
using MySql.Data.MySqlClient;
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

    public override bool Equals(System.Object otherCuisine)
    {
      if (!(otherCuisine is Cuisine))
      {
        return false;
      }
      else
      {
        Cuisine newCuisine = (Cuisine) otherCuisine;
        bool idEquality = (this.GetId() == newCuisine.GetId());
        bool nameEquality = (this.GetCuisineName() == newCuisine.GetCuisineName());
        return (idEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetCuisineName().GetHashCode();
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"TRUNCATE TABLE cuisines;"; //TRUNCATE = deletes and resets ID
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO cuisines (cuisine_name) VALUES (@cuisineName);";

      MySqlParameter cuisineNameParameter = new MySqlParameter();
      cuisineNameParameter.ParameterName = "@cuisineName";
      cuisineNameParameter.Value = this._cuisineName;
      cmd.Parameters.Add(cuisineNameParameter);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
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

      conn.Close();

      return allCuisine;
    }
  }
}
