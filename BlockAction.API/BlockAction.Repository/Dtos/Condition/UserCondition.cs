
namespace BlockAction.Repository.Dtos.Condition
{
    /// <summary>
    /// 使用者基本資料搜尋參數
    /// </summary>
    public class UserCondition
    {
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
    /// 用戶資金明細參數
    /// </summary>
    public class UserSearchCondition
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年齡下限
        /// </summary>
        public int? MinAge { get; set; }

        /// <summary>
        /// 年齡上限
        /// </summary>
        public int? MaxAge { get; set; }

        /// <summary>
        /// 餘額下限
        /// </summary>
        public decimal? MinMoney { get; set; }

        /// <summary>
        /// 餘額上限
        /// </summary>
        public decimal? MaxMoney { get; set; }

        /// <summary>
        /// 標籤
        /// </summary>
        public string? Tag { get; set; }
    }

    /// <summary>
    /// 用戶新增資金明細參數
    /// </summary>
    public class UserFundDetailCondition
    {

        /// <summary>
        /// 使用者標號
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 帳戶類型
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// 金額變動後
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 操作人員
        /// </summary>
        public int OperatorUserId { get; set; }

    }

    /// <summary>
    /// 用戶資金明細搜尋參數
    /// </summary>
    public class UserFundDetailSearchCondition
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 帳戶類型
        /// </summary>
        public int? AccountType { get; set; }

        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndtTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Summary { get; set; }

    }

}
