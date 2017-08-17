using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurant.Models
{
  public class RestaurantView
  {
    // private int _id;
    private string _restaurantName;
    private string _location;
    private string _cuisineName;

    // public RestaurantView (string restaurantName, string location, string cuisineName)
    // {
    //   // _id = id;
    //   _restaurantName = restaurantName;
    //   _location = location;
    //   _cuisineName = cuisineName;
    // }
    // // public int GetId()
    // {
    //   return _id;
    // }
    public string GetRestaurantName()
    {
      return _restaurantName;
    }
    public string GetLocation()
    {
      return _location;
    }
    public string GetCuisineName()
    {
      return _cuisineName;
    }
    // public static List<RestaurantView> GetAllRestaurantsForView(int cuisineId)
    // {
    //   List<RestaurantView> restaurants = new List<RestaurantView>();
    //
    //   MySqlConnection conn = DB.Connection() as MySqlConnection;
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT restaurants.restaurant_name,  restaurants.location, cuisines.cuisine_name FROM restaurants JOIN cuisines ON cuisines.id = restaurants.@cuisine_id;";
    //
    //   MySqlParameter cuisineIdParameter = new MySqlParameter();
    //   cuisineIdParameter.ParameterName = "@cuisine_id";
    //   cuisineIdParameter.Value = cuisineId;
    //   cmd.Parameters.Add(cuisineIdParameter);
    //
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   // int restaurantId = 0;
    //   string restaurantName = "";
    //   string location = "";
    //   cuisineId = 0;
    //   RestaurantView restaurant = new RestaurantView
    //   while (rdr.Read())
    //   {
    //
    //     restaurantName = rdr.GetString(1);
    //     location = rdr.GetString(2);
    //     int cuisineId = rdr.GetInt32(3);
    //     RestaurantView newRestaurantView = new RestaurantView(restaurantName, location, cuisineName);
    //     restaurants.Add(newRestaurantView);
    //   }
    //
    //   conn.Close();
    //
    //   return restaurants;

    //}
  }
}
