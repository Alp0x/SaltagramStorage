using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { options.LoginPath = "/login"; });

var storageUri = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_URI");
var storageAccountKey = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_KEY");
var accountName = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_NAME");

builder.Services.AddSingleton<TableClient>(new TableClient(
    new Uri(storageUri),
    "SaltagramTable",
    new TableSharedKeyCredential(accountName, storageAccountKey)
));
// Configure the HTTP request pipeline.
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();