using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using WebHooks.API.Models.TeamworkTicket;

namespace WebHooks.API.Controllers
{
    [ApiController]
    [Route("ticketmanagerservice")]
    public class StatusController : ControllerBase
    {
        public IActionResult IsRunning(string? response)
        {
            if (response ==null)
            {
                response = "Ok";
            } 
            return Ok(response);
        }
    }
}
