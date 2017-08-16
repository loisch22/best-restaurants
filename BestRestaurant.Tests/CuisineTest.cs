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

  }
}
