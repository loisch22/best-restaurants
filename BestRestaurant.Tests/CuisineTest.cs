using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BestRestaurant.Models;

namespace BestRestaurant.Tests
{
  [TestClass]
  public class CuisineTest : IDisposable
  {
    public void Dispose()
    {
      // Cuisine.DeleteAll();
    }
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restauarants_test;";
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
  }
}
