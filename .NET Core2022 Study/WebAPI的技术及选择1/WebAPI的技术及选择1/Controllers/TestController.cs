using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI的技术及选择1.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /*
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id必须是正数");
            }
            else if (id == 1)
            {
                return new Person(1, "Zane", 18);
            }
            else if (id == 2)
            {
                return new Person(2, "Cool", 8);
            }
            else
            {
                return NotFound("人员不存在");//自定义消息很重要
            }
        }*/
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ErrorInfo(1, "id必须是正数"));
            }
            else if (id == 1)
            {
                return new Person(1, "Zane", 18);
            }
            else if (id == 2)
            {
                return new Person(2, "Cool", 8);
            }
            else
            {
                return NotFound(new ErrorInfo(2, "人员不存在"));
            }
        }

    }
}
