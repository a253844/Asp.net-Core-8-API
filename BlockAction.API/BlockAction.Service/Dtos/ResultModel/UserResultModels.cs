
namespace BlockAction.Service.Dtos.ResultModel
{
    /// <summary>
    /// 用户基本资料
    /// </summary>
    public class UserResultModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
    }

    /// <summary>
    /// 用户基本资料
    /// </summary>
    public class UserFundDetailResultModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// 金额变动前
        /// </summary>
        public decimal BeforeBalance { get; set; }

        /// <summary>
        /// 金额变动后
        /// </summary>
        public decimal AfterBalance { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateOnly CreateTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public int OperatorUserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
    }
}
