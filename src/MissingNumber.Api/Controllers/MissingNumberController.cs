using Microsoft.AspNetCore.Mvc;
using MissingNumber.Application;
using MissingNumber.Application.Interfaces;

namespace MissingNumber.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissingNumberController : ControllerBase
{
    private readonly IInputParser _parser;
    private readonly IValidationService _validator;
    private readonly IMissingNumberFinderFactory _factory;

    public MissingNumberController(IInputParser parser, IValidationService validator, IMissingNumberFinderFactory factory)
    {
        _parser = parser;
        _validator = validator;
        _factory = factory;
    }

    [HttpPost("find")]
    public IActionResult FindMissing([FromBody] MissingNumberRequest request)
    {
        try
        {
            var numbers = _parser.Parse(string.Join(",", request.Numbers));
            _validator.Validate(numbers);

            var finder = _factory.Create(request.Algorithm ?? AlgorithmType.Xor);
            var missing = finder.FindMissing(numbers);

            return Ok(new { MissingNumber = missing, Algorithm = request.Algorithm ?? AlgorithmType.Xor });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}

public class MissingNumberRequest
{
    public List<int> Numbers { get; set; } = new();
    public AlgorithmType? Algorithm { get; set; }
}
