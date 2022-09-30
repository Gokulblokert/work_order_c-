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
// Get All Record From Workorder
    [HttpGet("Getall")]
    public IActionResult GetAll()
    {
       var work =this._DBContext.WorkTbs.ToList();
       return Ok(work);
    }
// Get Record From Workorder datetime;
        [HttpGet("Getorderdate/{workorderdate}")]
    public IActionResult Getorderdate(DateTime workorderdate)
    {
   
       var work =this._DBContext.WorkTbs.Where(w => w.DateTime ==  workorderdate).ToList();
       return Ok(work);
    }

    // Create New Workorder
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

    // Delete Record From Workorder

[HttpDelete("Remove/workid")]
    public IActionResult Remove(int workid)
    {
        try
        {
            var work=this._DBContext.WorkTbs.FirstOrDefault(o=>o.WorkId==workid);
            if (work != null)
            {
                 this._DBContext.Remove(work);
                 this._DBContext.SaveChanges();
            }
        }
        catch (Exception)
        {
             return Ok(false) ;
        }
        return Ok(true) ;
    }


    // Create new Technician

    [HttpPost("CreateTechh")]
     public  IActionResult CreateTechh([FromBody] TechnicianTb tecch)
    {
        try
        {
            this._DBContext.TechnicianTbs.Add(tecch);
            this._DBContext.SaveChanges();
        }
        catch (Exception)
        {
            return Ok(false) ;
        }
        return Ok(true) ;
    }

        [HttpPost("deactivetechnician")]
     public  IActionResult deactivetechnician([FromBody] TechnicianTb _tech)
    {
        try
        {
            var techh=this._DBContext.TechnicianTbs.Where(t=> t.TechRegister==_tech.TechRegister);
            if(techh != null){
            _tech.Status="0";
            this._DBContext.SaveChanges();
            }
        }
        catch (Exception)
        {
            return Ok(false) ;
        }
        return Ok(true) ;
    }

    
//         [HttpGet("assigntechnician/workid/techid")]
//      public  IActionResult assigntechnician(int workid,String techid)
//     {
//         String stats;
//         try
//         {

//             var techid1 = this._DBContext.TechnicianTbs.Where(t => t.Registerno ==  techid && t.Status == "1").FirstOrDefault();
//  if (techid != null)  
//             {  

// 		var workorder = this._DBContext.WorkTbs.Where(w => w.WorkId == workid).FirstOrDefault();
// 		 if (workorder != null)  
//             {   
//  		        workorder.TechicianRegisterno =techid1.Registerno;  
//                 _DBContext.SaveChanges();  
// 		stats = "Work Assign";
// 	     }
               
//             } else{
//  		stats = "Techician registerno is not active";
// 		}

//         }
//         catch (Exception)
//         {
//             return Ok(false) ;
//         }
//         return Ok(true) ;
//     }

}
