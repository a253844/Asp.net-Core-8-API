using AutoMapper;
using BlockAction.Repository.Dtos.Condition;
using BlockAction.Repository.Dtos.DataModel;
using BlockAction.Repository.Implement;
using BlockAction.Repository.Interface;
using BlockAction.Service.Dtos.Info;
using BlockAction.Service.Dtos.ResultModel;
using BlockAction.Service.Interface;
using BlockAction.Service.Mappings;
using Microsoft.Extensions.Logging;

namespace BlockAction.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        /// <summary>
        /// 建構式
        /// </summary>
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            this._userRepository = userRepository;
            this._logger = logger;

            var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<ServiceMappings>());

            this._mapper = config.CreateMapper();
        }

        #region 用户资讯

        /// <summary>
        /// 查詢用户列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IEnumerable<UserResultModel> GetList(UserSearchInfo info)
        {
            _logger.LogInformation("--------------GET Service.-----------------");
            var condition = this._mapper.Map<UserSearchInfo, UserSearchCondition>(info);
            var data = this._userRepository.GetList(condition);

            var result = this._mapper.Map<
                IEnumerable<Userdatainfo>,
                IEnumerable<UserResultModel>>(data);

            return result;
        }

        /// <summary>
        /// 查詢用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <returns></returns>
        public UserResultModel Get(int id)
        {
            var User = this._userRepository.Get(id);
            var result = this._mapper.Map<Userdatainfo, UserResultModel>(User);
            return result;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(UserInfo info)
        {
            var condition = this._mapper.Map<UserInfo, UserCondition>(info);
            var result = this._userRepository.Insert(condition);
            return result;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(int id, UserInfo info)
        {
            var condition = this._mapper.Map<UserInfo, UserCondition>(info);
            var result = this._userRepository.Update(id, condition);
            return result;
        }

        /// <summary>
        /// 刪除用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var result = this._userRepository.Delete(id);
            return result;
        }


        #endregion

        #region 用户资金明细

        /// <summary>
        /// 新增用户資金明細
        /// </summary>
        /// <returns></returns>
        public bool InsertFundDetial(UserFundDetailInfo info)
        {
            var condition = this._mapper.Map<UserFundDetailInfo, UserFundDetailCondition>(info);
            var result = this._userRepository.InsertFundDetial(condition);
            return result;
        }

        /// <summary>
        /// 查詢用户资金明细列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserFundDetailResultModel> GetFundDetialList(UserFundDetailSearchInfo info)
        {
            var condition = this._mapper.Map<UserFundDetailSearchInfo, UserFundDetailSearchCondition>(info);
            var data = this._userRepository.GetFundDetialList(condition);

            var result = this._mapper.Map<
                IEnumerable<Userfundetail>,
                IEnumerable<UserFundDetailResultModel>>(data);

            return result;
        }

        #endregion
    }
}
