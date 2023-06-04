using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CommunityGarden.Data;
using CommunityGarden.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CommunityGardenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommunityGardenContext") ?? throw new InvalidOperationException("Connection string 'CommunityGardenContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

app.MapGet("/users", async (CommunityGardenContext db) =>
    await db.User.ToListAsync());

app.MapGet("/users/{id}", async (int id, CommunityGardenContext db) =>
{
    var grocery = await db.Users.FindAsync(id);

    return grocery != null ? Results.Ok(grocery) : Results.NotFound();
});

app.MapPost("/users", async (User user, CommunityGardenContext db) =>
{
    db.Users.Add(user);

    await db.SaveChangesAsync();

    return Results.Created($"/users/{user.UserId}", user);
});

app.MapDelete("/users/{id}", async (int id, CommunityGardenContext db) =>
{
    var grocery = await db.Users.FindAsync(id);

    if (grocery != null)
    {
        db.Users.Remove(grocery);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.MapPut("/users/{id}", async (int id, User user, CommunityGardenContext db) =>
{
    var userInDb = await db.User.FindAsync(id);

    if (userInDb != null)
    {
        userInDb = user;

        await db.SaveChangesAsync();
        return Results.Ok(userInDb);
    }

    return Results.NotFound();
});