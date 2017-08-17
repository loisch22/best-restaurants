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

    public static void DeleteCuisine(int cuisineId)
    {

      Restaurant.DeleteCuisineRestaurants(cuisineId);

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM cuisines WHERE id = @id;";

      MySqlParameter cuisineIdParameter = new MySqlParameter();
      cuisineIdParameter.ParameterName = "@id";
      cuisineIdParameter.Value = cuisineId;
      cmd.Parameters.Add(cuisineIdParameter);

      cmd.ExecuteNonQuery();

      conn.Close();
    }

    public static void DeleteAll()
    {
      Restaurant.DeleteAll();
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

    public void UpdateCuisine(string cuisineName)
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE cuisines SET cuisine_name = @cuisine_name WHERE id = @id;";


      MySqlParameter cuisineNameParameter = new MySqlParameter();
      cuisineNameParameter.ParameterName = "@cuisine_name";
      cuisineNameParameter.Value = cuisineName;
      cmd.Parameters.Add(cuisineNameParameter);

      MySqlParameter cuisineIdParameter = new MySqlParameter();
      cuisineIdParameter.ParameterName = "@id";
      cuisineIdParameter.Value = this._id;
      cmd.Parameters.Add(cuisineIdParameter);

      cmd.ExecuteNonQuery();
      conn.Close();
    }
    //This method will return the cuisine that is found OR return null
    public static Cuisine FindCuisineByName(string cuisineName)
    {
      //maybe format cuisineName to a standard convention?

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM  cuisines WHERE cuisine_name = @cuisine_name;";

      MySqlParameter cuisineNameParameter = new MySqlParameter();
      cuisineNameParameter.ParameterName = "@cuisine_name";
      cuisineNameParameter.Value = cuisineName;
      cmd.Parameters.Add(cuisineNameParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      bool cuisineExists = false;

      int foundCuisineId = 0;
      string foundCuisineName = "";

      while(rdr.Read())
      {
        foundCuisineId = rdr.GetInt32(0);
        foundCuisineName = rdr.GetString(1);
        cuisineExists = true;
      }
      if (cuisineExists)
      {
        Cuisine foundCuisine = new Cuisine(foundCuisineName, foundCuisineId);
        conn.Close();
        return foundCuisine;
      }
      conn.Close();
      return null;
    }
  }
}
