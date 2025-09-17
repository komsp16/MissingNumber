using Microsoft.AspNetCore.Mvc;
using MissingNumber.Application;
using MissingNumber.Application.Interfaces;

namespace MissingNumber.Web.Controllers;

public class HomeController : Controller
{
    private readonly IInputParser _parser;
    private readonly IValidationService _validator;
    private readonly IMissingNumberFinderFactory _factory;

    public HomeController(IInputParser parser, IValidationService validator, IMissingNumberFinderFactory factory)
    {
        _parser = parser;
        _validator = validator;
        _factory = factory;
    }

    [HttpGet]
    public IActionResult Index() => View(new MissingNumberVm());

    [HttpPost]
    public IActionResult Index(MissingNumberVm vm)
    {
        try
        {
            var parsed = _parser.Parse(vm.RawInput ?? string.Empty);
            _validator.Validate(parsed);
            var finder = _factory.Create(vm.Algorithm);
            vm.Result = finder.FindMissing(parsed);
            vm.Error = null;
        }
        catch (Exception ex)
        {
            vm.Result = null;
            vm.Error = ex.Message;
        }
        return View(vm);
    }
}

public class MissingNumberVm
{
    public string? RawInput { get; set; }
    public AlgorithmType Algorithm { get; set; } = AlgorithmType.Xor;
    public int? Result { get; set; }
    public string? Error { get; set; }
}
