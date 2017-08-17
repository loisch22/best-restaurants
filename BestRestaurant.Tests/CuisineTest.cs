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

    [TestMethod]
    public void DeleteCuisine_DeletesASpecificCuisine_Void()
    {
      Cuisine newCuisine1 = new Cuisine("mexican");
      Cuisine newCuisine2 = new Cuisine("chinese");
      newCuisine1.Save();
      newCuisine2.Save();

      Restaurant newRestaurant1 = new Restaurant("Chipotle", "Seattle", 1, 1);
      Restaurant newRestaurant2 = new Restaurant("Chiangs", "Northgate", 2, 2);
      newRestaurant1.Save();
      newRestaurant2.Save();

      Cuisine.DeleteCuisine(newCuisine1.GetId());

      bool expected = false;
      bool actual = Cuisine.GetAllCuisines().Contains(newCuisine1) && Restaurant.GetAllRestaurants().Contains(newRestaurant1);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void UpdateCuisine_UpdateCuisineName_Void()
    {
      Cuisine newCuisine1 = new Cuisine("ethiopian");
      newCuisine1.Save();
      newCuisine1.UpdateCuisine("chinese");

      Cuisine expected = new Cuisine("chinese", 1);
      Cuisine actual = Cuisine.GetAllCuisines()[0];

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FindCuisineByName_GetsCuisineAndAssociatedRestaurants_Cuisine()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("mexican", 1);
      newCuisine.Save();

      Cuisine expected = newCuisine;
      Console.WriteLine("EXPECTED ========= {0} {1} ", expected.GetId(), expected.GetCuisineName());

      //Act
      Cuisine actual = Cuisine.FindCuisineByName(newCuisine.GetCuisineName());
      Console.WriteLine("ACTUAL ========= {0} {1} ", actual.GetId(), actual.GetCuisineName());
      //Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FindCuisineByName_CorrectlyFindsCuisinesThatExist_Cuisine()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("mexican");
      newCuisine.Save();
      //Act
      Cuisine expected = null;
      Cuisine actual = Cuisine.FindCuisineByName("italian");

      //Assert
      Assert.AreEqual(expected, actual);
    }


  }
}
