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

        [HttpGet("Getorderdate/{workorderdate}")]
    public IActionResult Getorderdate(DateTime workorderdate)
    {
   
       var work =this._DBContext.WorkTbs.Where(w => w.DateTime ==  workorderdate).ToList();
       return Ok(work);
    }
[HttpPost("Create")]
     public  IActionResult Create([FromBody] WorkTb _worwk)
    {
        try
        {
            this._DBContext.WorkTbs.Add(_worwk);
            this._DBContext.SaveChanges();
        }
        catch (Exception)
        {
            return Ok(false) ;
        }
        return Ok(true) ;
    }
}
