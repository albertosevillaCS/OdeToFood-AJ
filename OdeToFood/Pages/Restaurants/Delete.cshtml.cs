using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        public Restaurant Restaurant { get; set; } //-- This will help us to connect to OdeToFood.Core/Restaurant.cs and OdeToFood.Core/CuisineType.cs and get the Restaurant Data/Variables
        private readonly IRestaurantData restaurantData; 

        public DeleteModel(IRestaurantData restaurantData) //-- Inject IRestaurantData(Restaurant Details) into Delete Model
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId); //-- Populate Restaurant Details base/depends on restaurantId
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId); //-- Delete Restaurant Details base/depends on restaurantId then store the restaurant details on variable restaurant.
            restaurantData.Commit(); 

            if(restaurant == null) 
            {
                RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}
