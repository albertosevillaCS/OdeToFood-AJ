

using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;

var builder = WebApplication.CreateBuilder(args);





//-- This is how you configure a connection into your database.
builder.Services.AddDbContextPool<OdeToFoodDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OdeToFoodDb"));
});

// builder.Services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();
//----------------------------------------------------------------------------------------







// Add services to the container.

//-- The 2 services below helps the system to Implement the api controllers.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



/* This is how you build a custom Middleware with Request and Response
app.Run(async context =>
{
    if (context.Request.Path.StartsWithSegments("/hello"))
    {
        await context.Response.WriteAsync("Hello world!");
    }
    else
    {

    }
});
*/


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseNodeModules(); //-- I inputted this so that node_modules will work
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


//-- ERRRRRRRRRRROOOOOOOOOOOOOOOOOOOOOOORRRRRRRR

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});
//-----

app.Run();
