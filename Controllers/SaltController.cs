using Microsoft.AspNetCore.Mvc;
using Azure.Data.Tables;
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

    public IActionResult Salts() //Salt Gallery List LIKE/COMMENTS    PATCH
    {
        return View(new Salt[]
        {
            new Salt{
                Name = "Good Salt",
                GrainSize = "Big",
                Description = "Salty looking salty tasting",
                SourceSize = "1000000"
            },
            new Salt{
                Name = "Better Salt",
                GrainSize = "Gigantic",
                Description = "Saltier looking saltier tasting",
                SourceSize = "1000"
            }
        });
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