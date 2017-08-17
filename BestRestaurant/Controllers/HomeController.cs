using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System;
using System.Collections.Generic;

namespace BestRestaurant.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/CuisineForm")]
    public ActionResult CuisineForm()
    {
      return View();
    }

    [HttpPost("/CuisineList")]
    public ActionResult CuisineList()
    {
      Cuisine newCuisine = new Cuisine(Request.Form["cuisineName"]);
      newCuisine.Save();

      List<Cuisine> allCuisines = Cuisine.GetAllCuisines();

      return View(allCuisines);
    }

    [HttpGet("/RestaurantForm")]
    public ActionResult RestaurantForm()
    {
      return View();
    }

    [HttpPost("/RestaurantList")]
    public ActionResult RestaurantList()
    {
      // Restaurant.DeleteAll();
      // Cuisine.DeleteAll();

      string name = Request.Form["restaurantName"];
      string location = Request.Form["location"];
      string cuisineName = Request.Form["cuisineName"];
      Console.WriteLine("FOUND NAME =========" + cuisineName);
      Cuisine newCuisine = Cuisine.FindCuisineByName(cuisineName);
      if (newCuisine == null)
      {
        newCuisine = new Cuisine(cuisineName);
        newCuisine.Save();
      }
      int cuisineId = newCuisine.GetId();
      Restaurant newRestaurant = new Restaurant(name, location, cuisineId);
      newRestaurant.Save();

      List<Restaurant> restaurants = Restaurant.GetAllRestaurants();

      return View(restaurants);
    }
  }
}
