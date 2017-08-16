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
      Cuisine.DeleteAll();
    }
    public CuisineTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restauarants_test;";
    }
  }
}
