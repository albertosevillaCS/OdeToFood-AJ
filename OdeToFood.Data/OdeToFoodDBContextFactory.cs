using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    internal class OdeToFoodDBContextFactory : IDesignTimeDbContextFactory<OdeToFoodDbContext>
    {
        public OdeToFoodDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OdeToFoodDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OdeToFood;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new OdeToFoodDbContext(optionsBuilder.Options);
        }
    }
}
