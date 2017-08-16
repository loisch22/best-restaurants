using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace BestRestaurant.Tests
{
  [TestClass]
  public class RestaurantTest : IDisposable
  {
    public void Dispose()
    {
      // Restaurant.DeleteAll();
    }
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best_restauarants_test;";
    }


  }
}
