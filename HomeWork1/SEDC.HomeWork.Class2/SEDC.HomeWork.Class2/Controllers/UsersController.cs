using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.HomeWork.Class2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(StaticDb.UserNames);
        }

        [HttpGet("{index}")]
        public ActionResult<string> Get(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index has negative value!");
                }
                if (index >= StaticDb.UserNames.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no user with index {index}");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.UserNames[index]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                using(StreamReader streamReader = new StreamReader(Request.Body))
                {
                    string user = streamReader.ReadToEnd();
                    StaticDb.UserNames.Add(user);
                    return StatusCode(StatusCodes.Status201Created, "The user was created");
                }
            }
            catch(Exception e)
            {
                //to-do log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
               using(StreamReader streamReader = new StreamReader(Request.Body))
                {
                    string requestBody = streamReader.ReadToEnd();
                    int index = Int32.Parse(requestBody);
                    if(index < 0)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "The index has negative value!");
                    }
                    if(index >= StaticDb.UserNames.Count)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, $"There is no user with index {index}");
                    }
                    StaticDb.UserNames.RemoveAt(index);
                    return StatusCode(StatusCodes.Status204NoContent, "The user was deleted");
                }
            }
            catch(Exception e)
            {
                //to do log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

    }
}