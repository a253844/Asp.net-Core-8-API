using System.ComponentModel;

namespace BlockAction.Common
{
    internal class Emuns
    {

        /// <summary>
        /// 用户类型
        /// </summary>
        public enum UserType
        {
            /// <summary>
            /// 未知
            /// </summary>
            [Description("未知")]
            Unknown = 0,
            /// <summary>
            /// 普通用户
            /// </summary>
            [Description("正式")]
            OrdinaryUser = 10,
            /// <summary>
            /// 销售人员
            /// </summary>
            [Description("销售人员")]
            SalerUser = 20,
            /// <summary>
            /// 后台用户
            /// </summary>
            [Description("后台用户")]
            BackUser = 30,
            /// <summary>
            /// 测试账号
            /// </summary>
            [Description("测试")]
            TestAccount = 40,
            /// <summary>
            /// 游客账号
            /// </summary>
            [Description("游客账号")]
            GuestUser = 50,
        }

    }
}
