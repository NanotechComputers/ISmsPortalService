using System.Collections.Generic;
using System.Threading.Tasks;
using SmsPortal.Models;

namespace SmsPortal
{
    public interface ISmsPortalService
    {
        Task<MessageResponse> SendMessageAsync(string message, string mobile);
        Task<MessageResponse> SendMessagesAsync(List<Message> messages);
    }
}