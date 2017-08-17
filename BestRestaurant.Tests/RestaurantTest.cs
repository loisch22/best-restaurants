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

      Restaurant expected = newRestaurant1;
      //Act
      Restaurant actual = Restaurant.FindRestaurant("Chipotle");
      //Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DeleteAllRestaurants_DeletesAllRestaurants_Void()
    {
      //Arrange
      Restaurant newRestaurant = new Restaurant("Chipotle", "Seattle", 1);
      newRestaurant.Save();
      Restaurant.DeleteAll();

      int expected = 0;
      //Act
      int actual = Restaurant.GetAllRestaurants().Count;
      //Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void DeleteCuisineRestaurants_DeletesAllRestaurantsOfCuisine_Void()
    {
      //Arrange
      Restaurant newRestaurant = new Restaurant("Chipotle", "Seattle", 1, 1);
      int cuisineId = newRestaurant.GetId();
      newRestaurant.Save();
      Restaurant.DeleteCuisineRestaurants(cuisineId);

      int expected = 0;
      //Act
      int actual = Restaurant.GetRestaurantsForCuisine(cuisineId).Count;
      //Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void DeleteRestaurant_DeletesRestaurant_Void()
    {
      //Arrange
      Restaurant newRestaurant = new Restaurant("Chipotle", "Seattle", 1, 1);
      newRestaurant.Save();
      Restaurant newRestaurant2 = new Restaurant("Chipotle", "Seattle", 1, 1);
      newRestaurant2.Save();

      int restaurantId = newRestaurant.GetId();
      string restaurantName = newRestaurant.GetRestaurantName();
      Restaurant.DeleteRestaurant(restaurantId);

      bool expected = false;
      //Act
      bool actual = Restaurant.GetAllRestaurants().Contains(newRestaurant);
      //Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void UpdateRestaurant_UpdatesRestaurantDetails_Void()
    {
      Restaurant newRestaurant = new Restaurant("Chipotle", "Seattle", 1, 1);
      newRestaurant.Save();

      newRestaurant.UpdateRestaurant("Qdoba", "Northgate", 2);

      Restaurant expected = new Restaurant("Qdoba", "Northgate", 2, 1);
      Console.WriteLine(expected.GetRestaurantName() + " " + expected.GetLocation() + " " + expected.GetCuisineId() + " " + expected.GetId());

      Restaurant actual = Restaurant.GetAllRestaurants()[0];
      Console.WriteLine(actual.GetRestaurantName() + " " + actual.GetLocation() + " " + actual.GetCuisineId() + " " + actual.GetId());

      Assert.AreEqual(expected, actual);
    }
  }
}
