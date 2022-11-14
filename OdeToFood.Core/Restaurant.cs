using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, StringLength(80)] //-- Sample of DataAnnotations that needs to be met
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }


        public CuisineType Cuisine { get; set; }
    }
}
