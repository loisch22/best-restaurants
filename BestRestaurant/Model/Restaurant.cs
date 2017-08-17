using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    private int _id;
    private string _restaurantName;
    private string _location;
    private int _cuisineId;

    public Restaurant(string restaurantName, string location, int cuisineId, int id = 0)
    {
      _id = id;
      _restaurantName = restaurantName;
      _location = location;
      _cuisineId = cuisineId;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetRestaurantName()
    {
      return _restaurantName;
    }
    public string GetLocation()
    {
      return _location;
    }
    public int GetCuisineId()
    {
      return _cuisineId;
    }


    public override bool Equals(Object otherRestaurant)
    {
      if (!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool idEquality = (this.GetId() == newRestaurant.GetId());
        bool nameEquality = (this.GetRestaurantName() == newRestaurant.GetRestaurantName());
        return (idEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetRestaurantName().GetHashCode();
    }

    public void Save()
    {

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO restaurants(restaurant_name, location, cuisine_id) VALUES (@restaurant_name, @location, @cuisine_id);";

      MySqlParameter restaurantNameParameter = new MySqlParameter();
      restaurantNameParameter.ParameterName = "@restaurant_name";
      restaurantNameParameter.Value = this._restaurantName;
      cmd.Parameters.Add(restaurantNameParameter);

      MySqlParameter restaurantLocationParameter = new MySqlParameter();
      restaurantLocationParameter.ParameterName = "@location";
      restaurantLocationParameter.Value = this._location;
      cmd.Parameters.Add(restaurantLocationParameter);

      MySqlParameter cuisineIdParameter = new MySqlParameter();
      cuisineIdParameter.ParameterName = "@cuisine_id";
      cuisineIdParameter.Value = this._cuisineId;
      cmd.Parameters.Add(cuisineIdParameter);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
    }
    public static List<Restaurant> GetAllRestaurants()
    {
      List<Restaurant> restaurants = new List<Restaurant>();

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        string location = rdr.GetString(2);
        int cuisineId = rdr.GetInt32(3);
        Restaurant newRestaurant = new Restaurant(restaurantName, location, cuisineId, restaurantId);
        restaurants.Add(newRestaurant);
      }

      conn.Close();

      return restaurants;
    }
    public static List<Restaurant> GetRestaurantsForCuisine (int searchId)
    {
      List<Restaurant> restaurants = new List<Restaurant>();

      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants WHERE cuisine_id = @cuisine_id;";

      MySqlParameter cuisineIdParameter = new MySqlParameter();
      cuisineIdParameter.ParameterName = "@cuisine_id";
      cuisineIdParameter.Value = searchId;
      cmd.Parameters.Add(cuisineIdParameter);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        string location = rdr.GetString(2);
        int cuisineId = rdr.GetInt32(3);
        Restaurant newRestaurant = new Restaurant(restaurantName, location, cuisineId, restaurantId);
        restaurants.Add(newRestaurant);
      }

      conn.Close();
      return restaurants;
    }

    public static Restaurant FindRestaurant(string searchName)
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants WHERE restaurant_name = @restaurant_name;";

      MySqlParameter restaurantNameParameter = new MySqlParameter();
      restaurantNameParameter.ParameterName = "@restaurant_name";
      restaurantNameParameter.Value = searchName;
      cmd.Parameters.Add(restaurantNameParameter);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      Restaurant newRestaurant = new Restaurant("", "", 0);

      while (rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        string location = rdr.GetString(2);
        int cuisineId = rdr.GetInt32(3);
        newRestaurant = new Restaurant(restaurantName, location, cuisineId, restaurantId);
      }
      conn.Close();
      return newRestaurant;
    }

    public static void DeleteCuisineRestaurants(int cuisineId)
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants WHERE cuisine_id = @cuisineId;";
      MySqlParameter cuisineIdParameter = new MySqlParameter();
      cuisineIdParameter.ParameterName = "@cuisineId";
      cuisineIdParameter.Value = cuisineId;
      cmd.Parameters.Add(cuisineIdParameter);
      cmd.ExecuteNonQuery();

      conn.Close();
    }
    public static void DeleteRestaurant(int restaurantId)
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants WHERE id = @id;";

      MySqlParameter restaurantIdParameter = new MySqlParameter();
      restaurantIdParameter.ParameterName = "@id";
      restaurantIdParameter.Value = restaurantId;
      cmd.Parameters.Add(restaurantIdParameter);

      cmd.ExecuteNonQuery();

      conn.Close();
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection() as MySqlConnection;
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"TRUNCATE TABLE restaurants;";
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
