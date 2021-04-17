using FlexiSourceExam.Api.Models.Request;
using FlexiSourceExam.Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FlexiSourceExam.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ExamController : ControllerBase
    {
        private readonly ITextMatchingService _service;
        public ExamController(ITextMatchingService service) => _service = service;

        [HttpPost]
        public IActionResult Post([FromBody]ExamRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var response = _service.GetAllIndexResult(request, StringComparison.OrdinalIgnoreCase);
                return Ok(response);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
        }
    }
}
