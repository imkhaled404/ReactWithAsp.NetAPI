using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAPICrud.Models;

namespace ReactAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentDbContextcs _dbContextcs;
        public StudentController(StudentDbContextcs studentDbContextcs) 
        { 
            _dbContextcs = studentDbContextcs;
        }
        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _dbContextcs.Students.ToListAsync();
        }
        [HttpPost]
        [Route("AddStudent")]
        public async Task <Student> AddStudent(Student obj)
        {
            _dbContextcs.Students.Add(obj);
            await _dbContextcs.SaveChangesAsync();
            return obj;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student obj)
        {
            _dbContextcs.Entry(obj).State = EntityState.Modified;
            await _dbContextcs.SaveChangesAsync();
            return obj;
        }
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<Student> DeleteStudent(int id)
        {
            bool a = false;
            var student = _dbContextcs.Students.Find(id);
            if (student != null)
            {
                a = true;
                _dbContextcs.Entry(student).State = EntityState.Deleted;
                await _dbContextcs.SaveChangesAsync();

            }
            else
            {
                a = false;
            }

            return a; 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
