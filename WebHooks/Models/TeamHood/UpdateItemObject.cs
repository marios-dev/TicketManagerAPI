using Newtonsoft.Json;
using WebHooks.API.Interfaces;

namespace WebHooks.API.Models.TeamHood
{
    public partial class UpdateItemObject : IDeserializable<UpdateItemObject>
    {
        public Data Data { get; set; }

        public UpdateItemObject Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<UpdateItemObject>(json) ?? new UpdateItemObject();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public partial class Data
    {
        public bool Completed { get; set; }
        public Guid StatusId { get; set; }
        public long Color { get; set; }
        public string Description { get; set; }
        public List<WebHooks.API.Models.CustomField> CustomFields { get; set; }
        public List<string> Tags { get; set; }
    }
}
