using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BestRestaurant.Models;
using System;

namespace BestRestaurant.Tests
{
  [TestClass]
  public class RestaurantTest : IDisposable
  {
    public void Dispose()
    {
      Restaurant.DeleteAll();
    }
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
    }

    [TestMethod]
    public void Save_SaveRestaurantObject_Void()
    {
      Restaurant newRestaurant = new Restaurant("Chipotle", "Seattle", 1);
      newRestaurant.Save();

      List<Restaurant> expectedList = new List<Restaurant>{newRestaurant};
      List<Restaurant> actualList = Restaurant.GetAllRestaurants();

      int expected = 1;
      int actual = actualList.Count;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAllRestaurants_ReturnsAllRestaurants_RestaurantList()
    {
      //Arrange
      Restaurant newRestaurant = new Restaurant("Chipotle", "Seattle", 1);
      newRestaurant.Save();
      List<Restaurant> expected = new List<Restaurant>{newRestaurant};
      //Act
      List<Restaurant> actual = Restaurant.GetAllRestaurants();
      //Assert
      CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void GetRestaurantsForCuisine_ReturnsAllRestaurantsForThatCuisine_RestaurantList()
    {
      //Arrange
      Restaurant newRestaurant1 = new Restaurant("Chipotle", "Seattle", 1);
      newRestaurant1.Save();
      Restaurant newRestaurant2 = new Restaurant("Qdoba", "Seattle", 2);
      newRestaurant2.Save();

      List<Restaurant> expected = new List<Restaurant>{newRestaurant1};
      //Act
      List<Restaurant> actual = Restaurant.GetRestaurantsForCuisine(1);
      //Assert
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}
