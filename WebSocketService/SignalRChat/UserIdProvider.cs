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
            //这里通过request请求的Query方法来接受前端传递的userId的值，通过用户id作为来代替系统自带id，因为在实际项目中一般是要给指定的登录用户推送消息的
            //传递的时候连接地址后面加上?userId="558888"
            return connection.GetHttpContext().Request.Query["userId"].ToString();
        }
    }
}
