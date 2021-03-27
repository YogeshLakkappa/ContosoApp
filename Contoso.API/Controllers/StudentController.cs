using Contoso.Data;
using Contoso.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.API.Controllers
{
    public class StudentController : ApiController
    {
        private ContosoContext _context;

        public IHttpActionResult PostStudent(Student student)
        {
            _context = new ContosoContext();
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi",new { id = student.Id },student);
        }

        public List<Student> GetStudents()
        {
            _context = new ContosoContext();
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            _context = new ContosoContext();
            return _context.Students.Find(id);
        }

        public IHttpActionResult PutStudent(Student student)
        {
            _context = new ContosoContext();
            _context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteStudent(int id)
        {
            _context = new ContosoContext();
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok(student);
        }
    }
}
