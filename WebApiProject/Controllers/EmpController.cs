using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("AddEmp")]
        [HttpPost]
        public IActionResult AddNewEmp(Emp e)
        {
            db.employees.Add(e);
            db.SaveChanges();
            return Ok("Emp Added Successfully!!!");
        }

        [Route("GetEmps")]
        [HttpGet]
        public IActionResult GetAllEmpData()
        {
            var d = db.employees.ToList();
            return Ok(d);
        }

        [Route("DelEmp/{id}")]
        [HttpDelete]
        public IActionResult DeleteEmp(int id)
        {
            var find = db.employees.Find(id);
            db.employees.Remove(find);
            db.SaveChanges();
            return Ok("Emp Deleted Successfully!!");
        }

        [Route("UpdateEmp")]
        [HttpPatch]

        public IActionResult EditEmp(Emp emp)
        {
            db.employees.Update(emp);
            db.SaveChanges();
            return Ok("Emp Updated Successfully!!");
        }
    }
}
