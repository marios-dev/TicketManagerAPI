using System.Runtime.CompilerServices;
using TicketManagementAPI.Models.TeamHoodModels.Board;

namespace TicketManagementAPI.Interfaces
{
    public interface ITicketService
    {
        void GetTicket();//webhook requested payload
        void PassTicket(BoardItem boardItem);
    }
}