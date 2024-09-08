using Microsoft.AspNetCore.SignalR;

namespace SimpleBlog.Services.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceivedMessage",user, message);
        }
    }
}
