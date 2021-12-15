using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubService.Models
{
    public class MessageInfo
    {
        public string userid { get; set; }
        public string message { get; set; } = "Hello from server";
        public string username { get; set; } = "Server";
        public string groupid { get; set; } = "0";
        public string groupname { get; set; } = "Chung";
    }
}
