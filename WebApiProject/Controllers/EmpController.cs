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

        [Route("AddMultiple")]
        [HttpPost]
        public IActionResult AddEmpList(List<Emp> emp)
        {
            db.employees.AddRange(emp);
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

        [Route("DelMul")]
        [HttpDelete]
        public IActionResult DeleteMulEmp(List<int> id)
        {

            var data = db.employees.Where(x => id.Contains(x.Id)).ToList();
            db.employees.RemoveRange(data);
            db.SaveChanges();
            return Ok("Emp Deleted Successfully!!");
        }

        [Route("UpdateEmp")]
        [HttpPut]

        public IActionResult EditEmp(Emp emp)
        {
            db.employees.Update(emp);
            db.SaveChanges();
            return Ok("Emp Updated Successfully!!");
        }

        [Route("SearchEmp/{search}")]
        [HttpGet]
        public IActionResult SearchEmp(string search)
        {
            var result = db.employees.Where(x => search.Contains(x.Name) || search.Contains(x.Dept) || search.Contains(x.Salary.ToString()));
            return Ok(result);
        }
    }
}
