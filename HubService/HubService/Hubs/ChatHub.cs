using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubService.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendAllMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToGroup(string userid, string username, string groupid, string groupname, string message)
        {
            await Clients.Group(groupid).SendAsync("ReceiveGroupMessage", userid, username, groupid, groupname, message);
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public async Task AddUserToGroup(string[] groupids)
        {
            if (groupids != null)
                foreach (var groupid in groupids)
                    await Groups.AddToGroupAsync(Context.ConnectionId, groupid);
        }
    }
}
