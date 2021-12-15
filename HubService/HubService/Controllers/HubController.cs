using HubService.Hubs;
using HubService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public HubController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpPost("Send")]
        public async Task<object> Send([FromBody]MessageInfo info)
        {
            await _hubContext.Clients.Group(info.groupid).SendAsync("ReceiveGroupMessage", info.userid, info.username, info.groupid, info.groupname, info.message).ConfigureAwait(false);
            //https://code-maze.com/how-to-send-client-specific-messages-using-signalr/
            return Ok("Sent!");
        }
    }
}
