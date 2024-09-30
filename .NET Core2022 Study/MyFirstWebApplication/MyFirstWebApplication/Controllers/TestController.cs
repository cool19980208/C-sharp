using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public Person GetPerson()
        {
            return new Person(6,"Zane", 18);
        }
        [HttpPost]
        public string SaveNote(SaveNoteRequest req)
        {
            string filename = $"{req.Title}.txt";
            System.IO.File.WriteAllText(filename, req.Content);
            return filename;
        }

    }
}
