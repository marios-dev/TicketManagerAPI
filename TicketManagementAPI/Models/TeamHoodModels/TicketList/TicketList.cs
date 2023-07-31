using Newtonsoft.Json;
using WebHooks.API.Interfaces;

namespace TicketManagementAPI.Models.TeamHoodModels.TicketList;

public class TicketList
{
    [JsonProperty("tickets", NullValueHandling = NullValueHandling.Ignore)]
    public List<Ticket> Tickets { get; set; }

    [JsonProperty("included", NullValueHandling = NullValueHandling.Ignore)]
    public Included included { get; set; }

    [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
    public Pagination pagination { get; set; }

    [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
    public TicketListMeta Meta { get; set; }

    public void GetTicket()
    {
        Ticket ticket = new Ticket();

    }

    public class Included
    {
    }
}
