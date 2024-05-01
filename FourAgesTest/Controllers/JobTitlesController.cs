using FourAgesTest.Abstractions;
using FourAgesTest.Domain.Entities;
using FourAgesTest.HttpTypes;
using Microsoft.AspNetCore.Mvc;

namespace FourAgesTest.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class JobTitlesController : Controller
{
    private readonly IJobTitleService _service;

    public JobTitlesController(IJobTitleService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<JobTitle>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{jobTitleId:guid}")]
    [ProducesResponseType(typeof(JobTitle), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(Guid jobTitleId)
    {
        var result = await _service.GetById(jobTitleId);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(JobTitle), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateJobTitleRequest request)
    {
        var result = await _service.Create(request);
        return StatusCode(201, result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(JobTitle), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(JobTitle), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromBody] UpdateJobTitleRequest request)
    {
        try
        {
            var result = await _service.Update(request);
            return Ok(result);
        }
        catch (ArgumentException e)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("id:guid")]
    [ProducesResponseType(typeof(JobTitle), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create(Guid id)
    {
        try
        {
            await _service.Delete(id);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            return NotFound();
        }
    }
}