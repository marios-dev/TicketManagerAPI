using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using TicketManagementAPI.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace TicketManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BoardItemsController : ControllerBase
    {
        #region Ctor and constants
        private const string url = "https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/items";
        private readonly IBoardItemService _service;

        public BoardItemsController(IBoardItemService service)
        {
            this._service = service;
        }
        #endregion

        #region HTTP Post a new Board Item saved in case
        //[HttpGet]
        //probably works but needs proper HTTPPOST properties to function
        //returns 405code because of improper info of model,annotations and return type
        //public async Task<IActionResult> AddNewItem()
        //{
        //    //serialize the object
        //    //HttpPost to the API

        //    //dummy data
        //    List<CustomField> fields = new List<CustomField>();
        //    fields.Add(new CustomField { Name = "field1", Value = "1" });
        //    fields.Add(new CustomField { Name = "field2", Value = "2" });
        //    List<string> tags = new List<string>();
        //    tags.Add("tag1");
        //    tags.Add("tag2");

        //    var boarditem = new BoardItem()
        //    {
        //        BoardId = Guid.NewGuid(),
        //        AssignedUserId = Guid.NewGuid(),
        //        Budget = 456678,
        //        Color = 1,
        //        Completed = false,
        //        CustomFields = null,
        //        Description = "test desc",
        //        DueDate = DateTime.Now,
        //        Estimation = 123124,
        //        Milestone = true,
        //        OwnerId = Guid.NewGuid(),
        //        Progress = 23214,
        //        RowId = Guid.NewGuid(),
        //        StartDate = DateTime.Now,
        //        StatusId = Guid.NewGuid(),
        //        Tags = tags,
        //        Title = "testtitle",
        //        WorkspaceId = Guid.NewGuid()
        //    };
        //    //end dummy data

        //    //serialize and turn to httpcontent
        //    object data;
        //    string serializedJson = JsonConvert.SerializeObject(boarditem);
        //    HttpContent content = new StringContent(serializedJson, Encoding.UTF8, "application/json");

        //    //turn off redirection
        //    var handler = new HttpClientHandler();
        //    handler.AllowAutoRedirect = false;

        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        //    var client = new HttpClient(handler);
        //    try
        //    {
        //        var request2 = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Post,
        //            RequestUri = new Uri("https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/items"),
        //            Content = content
        //        };
        //        request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TeamHoodApiKey);
        //        var response2 = client.SendAsync(request2).Result;
        //        data = JsonConvert.DeserializeObject(response2.Content.ReadAsStringAsync().Result);
        //        Console.WriteLine(data);
        //        //json = await response2.Content.ReadAsStringAsync();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    return Ok();
        //}
        #endregion
    }
}
