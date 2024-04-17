using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.Mime;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using WebSocketService.SignalChat;

namespace WebSocketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSocketController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public WebSocketController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        /// <summary>
        /// 通过User的userId给指定登录用户发送消息
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        [HttpGet]
        public async Task SendMessageByUserId(string userId, string message)
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", message);
        }
        /// <summary>
        /// 给所有用户发送消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        [HttpGet("{message}")]
        public async Task SendMessageToAllUsers(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }

    }
}