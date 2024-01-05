using BlockAction.Repository.Dtos.Condition;
using BlockAction.Repository.Dtos.DataModel;
using BlockAction.Service.Dtos.Info;
using BlockAction.Service.Dtos.ResultModel;

namespace BlockAction.Service.Interface
{
    /// <summary>
    /// 用户管理服務
    /// </summary>
    public interface IUserService
    {

        #region 用戶資訊

        /// <summary>
        /// 查詢使用者列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserResultModel> GetList(UserSearchInfo info);

        /// <summary>
        /// 查詢用戶
        /// </summary>
        /// <param name="id">使用者編號</param>
        /// <returns></returns>
        UserResultModel Get(int id);

        /// <summary>
        /// 新增用戶
        /// </summary>
        /// <param name="parameter">使用者參數</param>
        /// <returns></returns>
        bool Insert(UserInfo info);

        /// <summary>
        /// 更新用戶
        /// </summary>
        /// <param name="id">使用者編號</param>
        /// <param name="parameter">使用者參數</param>
        /// <returns></returns>
        bool Update(int id, UserInfo info);

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
        bool InsertFundDetial(UserFundDetailInfo info);

        /// <summary>
        /// 查詢用戶資金明細列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserFundDetailResultModel> GetFundDetialList(UserFundDetailSearchInfo info);

        #endregion

    }
}
