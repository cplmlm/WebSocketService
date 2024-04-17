using Microsoft.AspNetCore.SignalR;

namespace WebSocketService.SignalChat
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// 重写连接事件，初次建立连接时进入此方法，开展具体业务可使用，例如管理连接池。
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("connected", Context.ConnectionId);
        }
        /// <summary>
        /// 重写断开事件，同理。
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
        /// <summary>
        /// 通过connectionId给指定用户发送消息
        /// </summary>
        /// <param name="connectionId">连接id</param>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        public async Task SendMessage(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }
        /// <summary>
        /// 通过useid给指定用户发送消息
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        public async Task SendMessageByUserId(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", message);
        }
        /// <summary>
        /// 全员广播
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        public async Task SendAllMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
