using Microsoft.AspNetCore.Mvc;
using Azure.Data.Tables;
using Azure;

public class SaltController : Controller
{
    private readonly TableClient _client;
    private readonly TableServiceClient _serviceClient;
    public SaltController(TableClient client, TableServiceClient serviceClient)
    {
        _client = client;
        _serviceClient = serviceClient;
    }
    public IActionResult Index() //Welcomepage POST
    {
        return View();
    }

    // // dynamic entities (<TableEntity>)
    // Pageable<TableEntity> queryResultsFilter =
    // tableClient.Query<TableEntity>
    // (filter: $"PartitionKey eq '{partitionKey}'");

    // // typed entities <POCO>
    // Pageable<Employee> queryResultsLINQ =
    // tableClient.Query<Employee>(ent => ent.Height >= 1.7);

    public IActionResult Salts() //Salt Gallery List LIKE/COMMENTS    PATCH
    {
        // var salts = new List<Salt>();

        var table = _serviceClient.GetTableClient("SaltTable");
        // var tableItems = table.Query<Salt>(opt => opt.PartitionKey == "PartitionKey");
        var tableItem = table.GetEntityAsync<Salt>("PartitionKey", "09a7d128-14c2-484f-9108-2ad58cc8eccd");

        // foreach (var item in tableItems)
        // {
        //     salts.Add(item);
        // }

        return View(tableItem);
    }

    public IActionResult Location() //LOCATION WHERE EACH SALT CAN BE FOUND
    {
        return View("Location");
    }

    [HttpPost("/AddSalt")]
    public IActionResult AddSalt()
    {
        var PartitionKey = "Salts";
        var RowKey = Guid.NewGuid().ToString();
        var Salt = new TableEntity(PartitionKey, RowKey){
                { "Name", "Table salt" },
                { "Description", "A description" }
            };
        _client.AddEntity(Salt);
        return View();
    }

    public IActionResult SaltProfile() // DETAILS WHERE U CAN UPDATE SPECIFIC SALT
    {
        return View(new Salt
        {
            Name = "Better Salt",
            GrainSize = "Gigantic",
            Description = "Saltier looking saltier tasting",
            SourceSize = "1000"
        });
    }

}