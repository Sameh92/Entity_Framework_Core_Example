using Book_Model;
using BookDataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityExampleBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleEnitiyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ExampleEnitiyController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet("getSchools")]
        public IActionResult getSchools()
        {
            var schools = _context.Schools.ToList();
            return Ok(schools);
        }
        [HttpPost("addSchool")]
        public IActionResult addSchool(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("updateSchool")]
        public IActionResult updateSchool(int schoolID)
        {
            var selectedSchool = _context.Schools.FirstOrDefault(x => x.Id==schoolID);
            selectedSchool.SchoolName = "updateSchoolSam";
            _context.Update(selectedSchool);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("deleteSchool")]
        public IActionResult deleteSchool(int schoolID)
        {
            var selectedSchool = _context.Schools.FirstOrDefault(x => x.Id == schoolID);            
            _context.Remove(selectedSchool);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("addBulk3")]
        public IActionResult addBulk3()
        {
           List < School > listSchool = new List<School>();
            for (int i = 0; i < 3; i++)
            {
                listSchool.Add(new School { SchoolName = Guid.NewGuid().ToString() });
            }
            _context.AddRange(listSchool);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("addBulk5")]
        public IActionResult addBulk5()
        {
            List<School> listSchool=new List<School>();
            for(int i=0;i<5;i++)
            {
                listSchool.Add(new School { SchoolName = Guid.NewGuid().ToString() });
            }
            _context.AddRange(listSchool);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("deleteBulk3")]
        public IActionResult deleteBulk3()
        {
            IEnumerable<School> listSchool = _context.Schools.OrderByDescending(s=>s.Id).Take(3);            
            _context.RemoveRange(listSchool);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("deleteBulk5")]
        public IActionResult deleteBulk5()
        {
            IQueryable<School> listSchool = _context.Schools.OrderByDescending(s => s.Id).Take(3); 
            _context.RemoveRange(listSchool);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("GetAsNoTrackingVSasTracking")]
        public IActionResult GetAsNoTrackingVSasTracking()
        {

            /*Whenever access anything using DbContext object it keeps trak of that object and the DbContext include the change tracker 
            class and it starts tracking all of the enitites as soon as it is retrieved using the DbContext 
            there are  5 cases to track the entities(addedd,unchanged,modified,deleted, detached
             */

            //when use add in dbContext the state change to added until saveChanges method after Save Changes the state change to Unchange

            //to check using _db.ChangeTracker.Entries() in side watch (_context.ChangeTracker.Entries())
            List<School> listSchool = _context.Schools.AsNoTracking().ToList();
            return Ok(listSchool);
        }

    }
}

