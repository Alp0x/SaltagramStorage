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

var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

var storageUri = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_URI");
var storageUri2 = Environment.GetEnvironmentVariable("AZURE_TABLE_SALTTABLE_URI");
var storageAccountKey = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_KEY");
var accountName = Environment.GetEnvironmentVariable("AZURE_TABLE_STORAGE_ACCOUNT_NAME");

var tableClient = new TableClient(
new Uri(storageUri),
"SaltagramTable",
new TableSharedKeyCredential(accountName, storageAccountKey));
await tableClient.CreateIfNotExistsAsync();

var table2Client = new TableClient(
new Uri(storageUri2),
"SaltTable",
new TableSharedKeyCredential(accountName, storageAccountKey));
await table2Client.CreateIfNotExistsAsync();

var rowKey = Guid.NewGuid().ToString();
var partitionKey = "PartitionKey";
var lastRowKey = "";

var address = new TableEntity(partitionKey, rowKey)
{
    { "City", "Marcus" },
    { "Street", "Teacher" },
    { "Housenumber", 8 }
};
table2Client.AddEntity(address);

for (int i = 0; i < 10; i++)
{
    lastRowKey = rowKey;
    var entity = new TableEntity(partitionKey, rowKey)
  {
      { "Name", "Marcus" },
      { "Role", "Teacher" },
      { "Skill", 0.8 * i }
  };
    tableClient.AddEntity(entity);
}

System.Console.WriteLine("Reading dynamic data...");
Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");
foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Name")}: {qEntity.GetDouble("Skill")}");
}
// Configure the HTTP request pipeline.
var app = builder.Build();
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

public class Employee : ITableEntity
{
    public string? Name { get; set; }
    public string? Role { get; set; }
    public double Skill { get; set; }
    public string? PartitionKey { get; set; }
    public string? RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    ETag ITableEntity.ETag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}