using AutoMapper;
using BlockAction.API.Filter;
using BlockAction.API.Mappings;
using BlockAction.API.Model;
using BlockAction.API.Parameter;
using BlockAction.Service.Dtos.Info;
using BlockAction.Service.Dtos.ResultModel;
using BlockAction.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using static BlockAction.API.Model.WebTool;

namespace BlockAction.API.Controllers
{
    #region 用户资讯

    /// <summary>
    /// 用户管理
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// 建構式
        /// </summary>
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            // 指定顯示層與邏輯層資料類別對映
            var config = new MapperConfiguration(cfg =>
                cfg.AddProfile<ControllerMappings>());

            this._mapper = config.CreateMapper();
            this._userService = userService;
            this._logger = logger;
        }

        /// <summary>
        /// 查詢用户列表
        /// </summary>
        /// <remarks>查询的条件未找到用户，则 Responses-data 回传空阵列</remarks>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("api/[controller]")]
        public ServerResponseInfo GetList([FromQuery] UserSearchParameter parameter)
        {
            _logger.LogInformation("--------------GET API.-----------------");

            var info = this._mapper.Map<
                UserSearchParameter,
                UserSearchInfo>(parameter);

            var Users = this._userService.GetList(info);

            var result = this._mapper.Map<
                IEnumerable<UserResultModel>,
                IEnumerable<UserViewModel>>(Users);

            return GetResonseInfo(result);
        }

        /// <summary>
        /// 查詢用户
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        /// <response code="200">回傳對應的用户</response>
        /// <response code="404">找不到該編號的用户</response>          
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ServerResponseInfo), 200)]
        [Route("api/[controller]/{id}")]
        public ServerResponseInfo Get([FromRoute] int id)
        {
            var User = this._userService.Get(id);

            if (User is null)
            {
                throw new Exception("查无此用户.");
            }

            var result = this._mapper.Map<
                UserResultModel,
                UserViewModel>(User);

            return GetResonseInfo(result);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <remarks></remarks>
        /// <param name="parameter">用户參數</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]")]
        public ServerResponseInfo Insert([FromBody] UserParameter parameter)
        {
            var info = this._mapper.Map<
                UserParameter,
                UserInfo>(parameter);

            var isInsertSuccess = this._userService.Insert(info);
            if (!isInsertSuccess)
            {
                throw new Exception("新增用户失败.");
            }
            return GetResonseInfo("");
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">用户編號</param>
        /// <param name="parameter">用户參數</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public ServerResponseInfo Update([FromRoute] int id, [FromBody] UserParameter parameter)
        {
            var targetUser = this._userService.Get(id);
            if (targetUser is null)
            {
                throw new Exception("查无此用户.");
            }

            var info = this._mapper.Map<
                UserParameter,
                UserInfo>(parameter);

            var isUpdateSuccess = this._userService.Update(id, info);
            if (!isUpdateSuccess)
            {
                throw new Exception("更新用户失败.");
            }
            return GetResonseInfo("");
        }

        /// <summary>
        /// 刪除用户
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">用户編號</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ServerResponseInfo Delete([FromRoute] int id)
        {
            var isDeleteSuccess = this._userService.Delete(id);
            if (!isDeleteSuccess)
            {
                throw new Exception("删除用户失败.");
            }
            return GetResonseInfo("");
        }

        #endregion

        #region 用户资金明细

        /// <summary>
        /// 查詢用户资金明细列表
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("api/[controller]/Fund")]
        public ServerResponseInfo GetFundDetialList([FromQuery] UserFundDetailSearchParameter parameter)
        {
            var info = this._mapper.Map<
                UserFundDetailSearchParameter,
                UserFundDetailSearchInfo>(parameter);

            var FundDetials = this._userService.GetFundDetialList(info);

            var result = this._mapper.Map<
                IEnumerable<UserFundDetailResultModel>,
                IEnumerable<UserFundDetailViewModel>>(FundDetials);

            return GetResonseInfo(result); ;
        }

        /// <summary>
        /// 新增用户資金明細
        /// </summary>
        /// <remarks></remarks>
        /// <param name="parameter">用户參數</param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("api/[controller]/Fund")]
        public ServerResponseInfo InsertFundDetial([FromBody] UserFundDetailParameter parameter)
        {
            var info = this._mapper.Map<
                UserFundDetailParameter,
                UserFundDetailInfo>(parameter);

            var targetUser = this._userService.Get(info.UserId);
            if (targetUser is null)
            {
                throw new Exception("查无此用户.");
            }

            var isInsertSuccess = this._userService.InsertFundDetial(info);
            if (!isInsertSuccess)
            {
                throw new Exception("新增用户资金明细失败.");
            }
            return GetResonseInfo("");
        }

        #endregion

        /// <summary>
        /// 错误讯息测试
        /// </summary>
        /// <remarks>测试发生Exception后的回传讯息</remarks>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("api/[controller]/Error")]
        public IActionResult GetError()
        {
            throw new Exception("Exception in HomeController.");
        }
    }
}
