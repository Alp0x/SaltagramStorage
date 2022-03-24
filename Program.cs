using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { options.LoginPath = "/login"; });
builder.Services.AddSingleton<TableServiceClient>(new TableServiceClient(Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING")));
builder.Services.AddSingleton<TableClient>(new TableClient(Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING"), "SaltagramTable"));
var app = builder.Build();

// var storageUri = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_URI");
// var accountName = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_NAME"); ;
// var storageAccountKey = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_KEY");

// var serviceClient = new TableServiceClient(
//     new Uri(storageUri),
//     new TableSharedKeyCredential(accountName, storageAccountKey));
// string tableName = "CreatedWithCodeTable";

// TableItem table = serviceClient.CreateTableIfNotExists(tableName);
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
