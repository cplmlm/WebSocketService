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
        /// ͨ��User��userId��ָ����¼�û�������Ϣ
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <param name="message">��Ϣ����</param>
        /// <returns></returns>
        [HttpGet]
        public async Task SendMessageByUserId(string userId, string message)
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", message);
        }
        /// <summary>
        /// �������û�������Ϣ
        /// </summary>
        /// <param name="message">��Ϣ����</param>
        /// <returns></returns>
        [HttpGet("{message}")]
        public async Task SendMessageToAllUsers(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }

    }
}