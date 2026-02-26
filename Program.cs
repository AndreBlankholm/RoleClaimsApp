using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoleClaimsApp.Data;


var builder = WebApplication.CreateBuilder(args);

// add service container

builder.Services.AddControllersWithViews();

var app = builder.Build();

RoleManager<IdentityRole> roleManager = app.Services.GetRequiredService<RoleManager<IdentityRole>>();

if (!await roleManager.RoleExistsAsync("Admin"))
{
    await roleManager.CreateAsync(new IdentityRole("Admin"));
}
if (!await roleManager.RoleExistsAsync("User"))
{
    await roleManager.CreateAsync(new IdentityRole("User"));
}

Claim claim = new Claim("Permission", "ManageEmployeeRecords");

await roleManager.AddClaimAsync(await roleManager.FindByNameAsync("HR"), claim);

// Map controllers
app.MapControllers();

app.Run();