using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [TempData]
        public string Message { get; set; }

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        //-- Y
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId); //-- Getting restaurant Details based on Id that depends on user selected value from List.cshtml into Detail.cshtml 
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}