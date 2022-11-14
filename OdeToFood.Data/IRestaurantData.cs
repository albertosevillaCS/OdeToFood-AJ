using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name); // Declaration of a List String property with a parameter of String "name",
                                                                   // the string "name" will become the variable that will store the user inputted Restaurant Name that will be used on InMemoryRestaurantData.cs


        Restaurant GetById(int id); // This will return data of restaurant based on id

        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);

        int GetCountOfRestaurants();
        int Commit();

    }
}
