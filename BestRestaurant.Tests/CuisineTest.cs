using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BestRestaurant.Models;

namespace BestRestaurant.Tests
{
  [TestClass]
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restaurants_test;";
    }
    public void Dispose()
    {
      Cuisine.DeleteAll();
    }

    [TestMethod]
    public void Save_SavesTheCuisineInstance_Void()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("mexican");

      newCuisine.Save();
      int expected = 1;
      //Act
      int actual = Cuisine.GetAllCuisines().Count;

      //Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAllCuisines_ReturnAllCuisines_CuisineList()
    {
      Cuisine newCuisine = new Cuisine("mexican", 1);
      newCuisine.Save();

      List<Cuisine> expected = new List<Cuisine>{newCuisine};
      List<Cuisine> actual = Cuisine.GetAllCuisines();

      CollectionAssert.AreEqual(expected, actual);
    }


      [TestMethod]
      public void DeleteAllCuisines_DeletesAllCuisinesAndAllRestaurants_Void()
      {
        //Arrange
        Cuisine newCuisine1 = new Cuisine("mexican");
        newCuisine1.Save();

        Restaurant newRestaurant1 = new Restaurant("Chipotle", "Seattle", 1, 1);
        newRestaurant1.Save();
        Cuisine.DeleteAll();
        
        //Act
        int actualRestaurants = Restaurant.GetAllRestaurants().Count;
        int actualCuisine = Cuisine.GetAllCuisines().Count;

        bool expected = true;
        bool actual = (0 == actualRestaurants && 0 == actualCuisine);
        //Assert
        Assert.AreEqual(expected, actual);
      }


  }
}
