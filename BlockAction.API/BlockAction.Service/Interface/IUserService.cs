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

        #region 用户资讯

        /// <summary>
        /// 查詢用户列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserResultModel> GetList(UserSearchInfo info);

        /// <summary>
        /// 查詢用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <returns></returns>   
        UserResultModel Get(int id);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="parameter">用户參數</param>
        /// <returns></returns>
        bool Insert(UserInfo info);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <param name="parameter">用户參數</param>
        /// <returns></returns>
        bool Update(int id, UserInfo info);

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
        bool InsertFundDetial(UserFundDetailInfo info);

        /// <summary>
        /// 查詢用户资金明细列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserFundDetailResultModel> GetFundDetialList(UserFundDetailSearchInfo info);

        #endregion

    }
}
