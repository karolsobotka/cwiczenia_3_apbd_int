using Cw3.Models;
using Cw3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IFileDbService _fileDbService;
        public StudentsController(IFileDbService fileDbService)
        {
            _fileDbService = fileDbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _fileDbService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            var student = _fileDbService.GetStudent(indexNumber);
            if (student is null) return NotFound("Nie znaleziono studenta o podanym indexie");
            return Ok(student);
        }
        

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {                  
            _fileDbService.AddStudent(student);

            return Created("Student utworzony", student);
        }

       

        [HttpDelete("{indexNumber}")]
        public IActionResult deleteStudent(string indexNumber)
        {
            _fileDbService.DeleteStudent(indexNumber);
            return Ok($"Student o numerze indeksu {indexNumber} został usunięty");

        }
        [HttpPut("{indexNumber}")]
        public IActionResult updateStudent([FromBody] Student student)
        {
            _fileDbService.UpdateStudent(student);
            return Ok($"Student o numerze indeksu {student.IndexNumber} zaktualizowany");
        }
    }
}
