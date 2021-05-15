using CollegeSystem.Models;
using CollegeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController: ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("get-subjects")]
        public IActionResult GetSubjects()
        {
            try
            {
                var response = _subjectService.GetSubjects();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-subject")]
        public IActionResult AddSubject([FromBody]SubjectRequestModel subjectRequest)
        {
            try
            {
                _subjectService.AddSubject(subjectRequest);
                return Ok("Subject successfully added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-subject")]
        public IActionResult UpdateSubject([FromBody]SubjectRequestModel subjectRequest, [FromQuery]int subjectId)
        {
            try
            {
                _subjectService.UpdateSubject(subjectRequest, subjectId);
                return Ok("Subject successfully added!");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete("delete-subject")]
        public IActionResult DeleteSubject([FromQuery]int subjectId)
        {
            try
            {
                _subjectService.DeleteSubject(subjectId);
                return Ok("Subject successfully deleted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
