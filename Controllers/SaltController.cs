using Microsoft.AspNetCore.Mvc;

public class SaltController : Controller
{
    public IActionResult Index() //Welcomepage POST
    {
        return View("Index");
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