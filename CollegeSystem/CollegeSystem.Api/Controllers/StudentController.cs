using CollegeSystem.Models;
using CollegeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController :ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("get-students")]
        public IActionResult GetStudents()
        {
            try
            {
                var response = _studentService.GetStudents();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("add-student")]
        public IActionResult AddStudent([FromBody]StudentRequestModel student)
        {
            try
            {
                _studentService.AddStudent(student);
                return Ok("Student successfully added!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-subject")]
        public IActionResult AddSubject([FromQuery] int studentId, [FromQuery] List<int> subjectIds)
        {
            try
            {
                _studentService.AddSubjectToStudent(studentId, subjectIds);
                return Ok("Subject/s successfully added!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-student")]
        public IActionResult UpdateStudent([FromBody]StudentRequestModel requestModel, [FromQuery]int studentId)
        {
            try
            {
                _studentService.UpdateStudent(requestModel, studentId);
                return Ok("Student successfully updated!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-student")]
        public IActionResult DeleteStudent([FromQuery] int studentId)
        {
            try
            {
                _studentService.DeleteStudent(studentId);
                return Ok("Student successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      


    }
}
