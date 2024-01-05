namespace BlockAction.API.Controllers
{
    public class WebTool
    {

        /// <summary>
        /// 服務端回复對象
        /// </summary>
        public class ServerResponseInfo
        {
            /// <summary>
            /// 回復結果
            /// </summary>
            public int code { get; set; } = 200;
            /// <summary>
            /// 回覆訊息
            /// </summary>
            public string message { get; set; } = "";
            /// <summary>
            /// 公共數據
            /// </summary>
            public string status { get; set; } = "ok";
            /// <summary>
            /// 業務數據
            /// </summary>
            public object data { get; set; } = "";
        }

        /// <summary>
        /// 取得回复對象
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
