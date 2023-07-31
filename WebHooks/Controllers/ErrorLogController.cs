//using Microsoft.AspNetCore.Mvc;
//using System.Text;

//namespace WebHooks.API.Controllers
//{
//      ---------------Implementation for logging WIP

//    //[Route("errorlog")]
//    //public class ErrorLogController : Controller
//    //{
//    //    private readonly ILogger<ErrorLogController> _logger;
//    //    private readonly List<string> _errorMessages = new List<string>();

//    //    public ErrorLogController(ILogger<ErrorLogController> logger)
//    //    {
//    //        _logger = logger;
//    //    }

//    //    public IActionResult CreateLog(string? error)
//    //    {
//    //        if (error != null)
//    //        {
//    //            _logger.LogError(error);
//    //            _errorMessages.Add(error);
//    //        }
//    //        else
//    //        {
//    //            error = "Error log started";
//    //            _logger.LogInformation(error);
//    //        }

//    //        return Ok("Log created");
//    //    }

//    //    [HttpGet("errorlog")]
//    //    public IActionResult GetErrorLog()
//    //    {
//    //        return Ok(_errorMessages);
//    //    }
//    //}
//}
