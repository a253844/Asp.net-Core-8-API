using System.ComponentModel;

namespace BlockAction.Common
{
    internal class Emuns
    {

        /// <summary>
        /// 使用者類型
        /// </summary>
        public enum UserType
        {
            /// <summary>
            /// 未知
            /// </summary>
            [Description("未知")]
            Unknown = 0,
            /// <summary>
            /// 普通用戶
            /// </summary>
            [Description("正式")]
            OrdinaryUser = 10,
            /// <summary>
            /// 銷售人員
            /// </summary>
            [Description("銷售人員")]
            SalerUser = 20,
            /// <summary>
            /// 後台用戶
            /// </summary>
            [Description("後台使用者")]
            BackUser = 30,
            /// <summary>
            /// 測試帳號
            /// </summary>
            [Description("測試")]
            TestAccount = 40,
            /// <summary>
            /// 遊客帳號
            /// </summary>
            [Description("遊客帳號")]
            GuestUser = 50,
        }

    }
}
