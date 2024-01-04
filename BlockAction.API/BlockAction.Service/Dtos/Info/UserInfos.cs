
using System.ComponentModel.DataAnnotations;

namespace BlockAction.Service.Dtos.Info
{
    /// <summary>
    /// 用户基本资料搜尋參數
    /// </summary>
    public class UserInfo
    {
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
    /// 用户搜尋參數
    /// </summary>
    public class UserSearchInfo
    {
        /// <summary>
        /// 用户名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄下限
        /// </summary>
        public int? MinAge { get; set; }

        /// <summary>
        /// 年龄上限
        /// </summary>
        public int? MaxAge { get; set; }

        /// <summary>
        /// 余额下限
        /// </summary>
        public decimal? MinMoney { get; set; }

        /// <summary>
        /// 余额上限
        /// </summary>
        public decimal? MaxMoney { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string? Tag { get; set; }
    }

    /// <summary>
    /// 用户资金明细參數
    /// </summary>
    public class UserFundDetailInfo
    {

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// 金额变动后
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public int OperatorUserId { get; set; }

    }

    /// <summary>
    /// 用户资金明细搜尋參數
    /// </summary>
    public class UserFundDetailSearchInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 用户名稱
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public int? AccountType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndtTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Summary { get; set; }

    }
}
