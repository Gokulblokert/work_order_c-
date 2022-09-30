using Microsoft.AspNetCore.Mvc;
using workorder.Models;
namespace workorder.Controllers;

[ApiController]
[Route("[controller]")]
public class workorder : ControllerBase
{
 

    private readonly testdbContext _DBContext;

    public workorder(testdbContext dbcontext)
    {
       this._DBContext=dbcontext;
    }

    [HttpGet("Getall")]
    public IActionResult GetAll()
    {
       var work =this._DBContext.WorkTbs.ToList();
       return Ok(work);
    }
}
