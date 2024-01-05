using BlockAction.Repository.Dtos.Condition;
using BlockAction.Repository.Dtos.DataModel;

namespace BlockAction.Repository.Interface
{
    /// <summary>
    /// 用户管理服務
    /// </summary>
    public interface IUserRepository
    {
        #region 用戶資訊

        /// <summary>
        /// 查詢使用者列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Userdatainfo> GetList(UserSearchCondition info);

        /// <summary>
        /// 查詢用戶
        /// </summary>
        /// <param name="id">使用者編號</param>
        /// <returns></returns>
        Userdatainfo Get(int id);

        /// <summary>
        /// 新增用戶
        /// </summary>
        /// <param name="info">使用者參數</param>
        /// <returns></returns>
        bool Insert(UserCondition info);

        /// <summary>
        /// 更新用戶
        /// </summary>
        /// <param name="id">使用者編號</param>
        /// <param name="info">使用者參數</param>
        /// <returns></returns>
        bool Update(int id, UserCondition info);

        /// <summary>
        /// 刪除用戶
        /// </summary>
        /// <param name="id">使用者編號</param>
        /// <returns></returns>
        bool Delete(int id);

        #endregion

        #region 用戶資金明細

        /// <summary>
        /// 新增使用者資金明細
        /// </summary>
        /// <param name="info">使用者參數</param>
        /// <returns></returns>
        bool InsertFundDetial(UserFundDetailCondition info);

        /// <summary>
        /// 查詢用戶資金明細列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Userfundetail> GetFundDetialList(UserFundDetailSearchCondition info);

        #endregion

    }
}
