using MechanicWebAppAPI.Common.Requests.ChatRequests;
using MechanicWebAppAPI.Core.Dtos.Message;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IChat
    {
        Task<MessageDto> Create(SendMessageRequest message);
        Task<IEnumerable<MessageDto>> GetMessagesByRoomId(Guid Room_id);
    }
}
