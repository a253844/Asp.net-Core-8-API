using AutoMapper;
using BlockAction.API.Filter;
using BlockAction.API.Mappings;
using BlockAction.API.Model;
using BlockAction.API.Parameter;
using BlockAction.Service.Dtos.Info;
using BlockAction.Service.Dtos.ResultModel;
using BlockAction.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using static BlockAction.API.Controllers.WebTool;

namespace BlockAction.API.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Asp.Versioning.ApiVersion("1.0")]
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

        #region 使用者訊息

        /// <summary>
        /// 查詢使用者列表
        /// </summary>
        /// <remarks>查詢的條件如果找不到，則 Responses-data 回傳空陣列</remarks>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("api/[controller]")]
        public ServerResponseInfo GetList([FromQuery] UserSearchParameter parameter)
        {
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
        /// 查詢用戶
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        /// <response code="200">回傳對應的使用者</response>
        /// <response code="404">找不到該編號的使用者</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ServerResponseInfo), 200)]
        [Route("api/[controller]/{id}")]
        public ServerResponseInfo Get([FromRoute] int id)
        {
            var User = this._userService.Get(id);

            if (User is null)
            {
                Response.StatusCode = 404;
                throw new Exception("查無此用戶.");
            }

            var result = this._mapper.Map<
                UserResultModel,
                UserViewModel>(User);

            return GetResonseInfo(result);
        }

        /// <summary>
        /// 新增用戶
        /// </summary>
        /// <remarks></remarks>
        /// <param name="parameter">使用者參數</param>
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
                throw new Exception("新增用戶失敗.");
            }
            return GetResonseInfo("");
        }

        /// <summary>
        /// 更新用戶
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">使用者編號</param>
        /// <param name="parameter">使用者參數</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public ServerResponseInfo Update([FromRoute] int id, [FromBody] UserParameter parameter)
        {
            var targetUser = this._userService.Get(id);
            if (targetUser is null)
            {
                throw new Exception("查無此用戶.");
            }

            var info = this._mapper.Map<
                UserParameter,
                UserInfo>(parameter);

            var isUpdateSuccess = this._userService.Update(id, info);
            if (!isUpdateSuccess)
            {
                throw new Exception("更新使用者失敗.");
            }
            return GetResonseInfo("");
        }

        /// <summary>
        /// 刪除用戶
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">使用者編號</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ServerResponseInfo Delete([FromRoute] int id)
        {
            var isDeleteSuccess = this._userService.Delete(id);
            if (!isDeleteSuccess)
            {
                throw new Exception("刪除用戶失敗.");
            }
            return GetResonseInfo("");
        }

        #endregion

        #region 用戶資金明細

        /// <summary>
        /// 查詢用戶資金明細列表
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
        /// 新增使用者資金明細
        /// </summary>
        /// <remarks></remarks>
        /// <param name="parameter">使用者參數</param>
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
                throw new Exception("查無此用戶.");
            }

            var isInsertSuccess = this._userService.InsertFundDetial(info);
            if (!isInsertSuccess)
            {
                throw new Exception("新增用戶資金明細失敗.");
            }
            return GetResonseInfo("");
        }

        #endregion

        /// <summary>
        /// 錯誤訊息測試
        /// </summary>
        /// <remarks>測試發生Exception後的回傳訊息</remarks>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("api/[controller]/Error")]
        public IActionResult GetError()
        {
            throw new Exception("Exception in UserController.");
        }
    }
}
