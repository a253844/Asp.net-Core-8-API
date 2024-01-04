using BlockAction.Repository.Dtos.Condition;
using BlockAction.Repository.Dtos.DataModel;

namespace BlockAction.Repository.Interface
{
    /// <summary>
    /// 用户管理服務
    /// </summary>
    public interface IUserRepository
    {
        #region 用户资讯

        /// <summary>
        /// 查詢用户列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Userdatainfo> GetList(UserSearchCondition info);

        /// <summary>
        /// 查詢用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <returns></returns>   
        Userdatainfo Get(int id);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="info">用户參數</param>
        /// <returns></returns>
        bool Insert(UserCondition info);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <param name="info">用户參數</param>
        /// <returns></returns>
        bool Update(int id, UserCondition info);

        /// <summary>
        /// 刪除用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <returns></returns>
        bool Delete(int id);

        #endregion

        #region 用户资金明细

        /// <summary>
        /// 新增用户資金明細
        /// </summary>
        /// <param name="info">用户參數</param>
        /// <returns></returns>
        bool InsertFundDetial(UserFundDetailCondition info);

        /// <summary>
        /// 查詢用户资金明细列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Userfundetail> GetFundDetialList(UserFundDetailSearchCondition info);

        #endregion

    }
}
