using System.Runtime.InteropServices;
using WebHooks.API.Models;
using WebHooks.API.Models.TeamworkTicket;

namespace WebHooks.API.Interfaces
{
    public interface IDeserializable<T>
    {
        T Deserialize(string json);
        string Serialize();
    }
}
