
namespace BlockAction.Service.Dtos.ResultModel
{
    /// <summary>
    /// 使用者基本資料
    /// </summary>
    public class UserResultModel
    {
        /// <summary>
        /// 使用者編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 使用者描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 餘額
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 標籤
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 年齡
        /// </summary>
        public int Age { get; set; }
    }

    /// <summary>
    /// 使用者基本資料
    /// </summary>
    public class UserFundDetailResultModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 使用者編號
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 帳戶類型
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// 金額變動前
        /// </summary>
        public decimal BeforeBalance { get; set; }

        /// <summary>
        /// 金額變動後
        /// </summary>
        public decimal AfterBalance { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateOnly CreateTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 操作人員
        /// </summary>
        public int OperatorUserId { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }
    }
}
