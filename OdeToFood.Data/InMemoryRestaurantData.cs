using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants; //-- List of Restaurant details and variables from OdeToFood.Core/Restaurant.cs

        public InMemoryRestaurantData() //-- This constructor provides the Restaurant Details based on variables on OdeToFood.Core/Restaurant.cs and OdeToFood.Core/CuisineType.cs
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1, Name="Mcdonalds", Location="East Kamias", Cuisine=CuisineType.Italian },
                new Restaurant { Id=2, Name="Jollibee", Location="West Kamias", Cuisine=CuisineType.Mexican },
                new Restaurant { Id=3, Name="KFC", Location="Caloocan City", Cuisine=CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) //-- This constructor includes the Query for searching specific Restaurant Name based on user input on List.cshtml file.
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id); // This code will return the restaurant data depends on Id to Detail Model 
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
