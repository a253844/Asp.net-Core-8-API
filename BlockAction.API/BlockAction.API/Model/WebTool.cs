
namespace BlockAction.API.Model
{
    public class WebTool
    {

        /// <summary>
        /// 服务端回复对象
        /// </summary>
        public class ServerResponseInfo
        {
            /// <summary>
            /// 回复结果
            /// </summary>
            public int code { get; set; } = 200;
            /// <summary>
            /// 回复消息
            /// </summary>
            public string message { get; set; } = "";
            /// <summary>
            /// 公共数据
            /// </summary>
            public string status { get; set; } = "ok";
            /// <summary>
            /// 业务数据
            /// </summary>
            public object data { get; set; } = "";
        }

        /// <summary>
        /// 获取回复对象
        /// </summary>
        public static ServerResponseInfo GetResonseInfo(object data, int code = 200, string message = "", string status = "ok")
        {
            return new ServerResponseInfo
            {
                code = code,
                message = message,
                status = status,
                data = data,
            };
        }

    }
}
