using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace WebSocketService.SignalChat
{
    public class UserIdProvider : IUserIdProvider
    {
        /// <summary>
        /// 使用声明自定义标识处理
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.GetHttpContext().Request.Query["userId"].ToString();
        }
    }
}
