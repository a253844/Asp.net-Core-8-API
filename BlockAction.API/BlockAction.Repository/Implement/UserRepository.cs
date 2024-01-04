using BlockAction.Repository.Dtos.Condition;
using BlockAction.Repository.Dtos.DataModel;
using BlockAction.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace BlockAction.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly DemodbContext _db;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DemodbContext dbContext, ILogger<UserRepository> logger)
        {
            this._db = dbContext;
            this._logger = logger;
        }

        #region 用户讯息

        /// <summary>
        /// 查詢用户列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<Userdatainfo> GetList(UserSearchCondition condition)
        {
            _logger.LogInformation("--------------GET Repository.-----------------");

            var Userinfos = _db.Userdatainfos.AsQueryable();

            if (!string.IsNullOrEmpty(condition.Name))
            {
                Userinfos = Userinfos.Where(p => p.Name == condition.Name);
            }

            if(condition.MinMoney != null && condition.MaxMoney != null)
            {
                Userinfos = Userinfos.Where(p => p.Money >= condition.MinMoney && p.Money <= condition.MaxMoney);
            }

            if(condition.MinMoney != null && condition.MaxMoney != null)
            {
                Userinfos = Userinfos.Where(p => p.Age >= condition.MinAge && p.Age <= condition.MaxAge);
            }

            if (!string.IsNullOrEmpty(condition.Tag))
            {
                Userinfos = Userinfos.Where(p => p.Tag.Contains(condition.Tag));
            }

            return Userinfos;
        }

        /// <summary>
        /// 查詢用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Userdatainfo Get(int id)
        {
            try
            {
                var Userinfos = _db.Userdatainfos.Where(p => p.Id == id ).OrderBy(p => p.Id).First();

                return Userinfos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="condition">參數</param>
        /// <returns></returns>
        public bool Insert(UserCondition condition)
        {
            try
            {
                var User = new Userdatainfo
                {
                    Name = condition.Name,
                    Description = condition.Description,
                    Money = condition.Money,
                    Tag = condition.Tag,
                    Age = condition.Age
                };

                _db.Userdatainfos.Add(User);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <param name="condition">參數</param>
        /// <returns></returns>
        public bool Update(int id, UserCondition condition)
        {
            var check = false;
            try
            {
                // 写入前检查用户是否存在
                var user = _db.Userdatainfos.FirstOrDefault(p => p.Id == id);
                if (user != null)
                {
                    user.Name = condition.Name;
                    user.Description = condition.Description;
                    user.Money = condition.Money;
                    user.Tag = condition.Tag;
                    user.Age = condition.Age;

                    _db.SaveChanges();

                    check = true;
                }

                return check;
            }
            catch (Exception ex)
            {
                return check;
            }
        }

        /// <summary>
        /// 刪除用户
        /// </summary>
        /// <param name="id">用户編號</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var check = false;
            try
            {
                // 写入前检查用户是否存在
                var user = _db.Userdatainfos.FirstOrDefault(p => p.Id == id);
                if (user != null)
                {
                    _db.Userdatainfos.Remove(user);
                    _db.SaveChanges();

                    check = true;
                }
               
                return check;
            }
            catch (Exception ex)
            {
                return check;
            }
            
        }

        #endregion

        #region 用户资金明细

        /// <summary>
        /// 用户资金明细
        /// </summary>
        /// <param name="condition">參數</param>
        /// <returns></returns>
        public bool InsertFundDetial(UserFundDetailCondition condition)
        {
            var check = false;
            try
            {
                // 写入前检查用户是否存在
                var user = _db.Userdatainfos.FirstOrDefault(p => p.Id == condition.UserId);

                if(user != null)
                {
                    var FundDetail = new Userfundetail
                    {
                        UserId = condition.UserId,
                        AccountType = condition.AccountType,
                        BeforeBalance = user.Money,
                        AfterBalance = user.Money + condition.Money,
                        CreateTime = DateOnly.FromDateTime(DateTime.Now.Date),
                        Summary = condition.Summary,
                        OperatorUserId = condition.OperatorUserId,
                        UserName = user.Name
                    };

                    // 更新帐变后，更新用户资讯金额
                    user.Money = FundDetail.AfterBalance;

                    _db.Userfundetails.Add(FundDetail);
                    _db.SaveChanges();

                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                return check;
            }
            
        }

        /// <summary>
        /// 查詢用户资金明细列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<Userfundetail> GetFundDetialList(UserFundDetailSearchCondition condition)
        {
            var Userinfos = _db.Userfundetails.Where(p => p.CreateTime >=  DateOnly.FromDateTime(condition.StartTime) && p.CreateTime <= DateOnly.FromDateTime(condition.EndtTime));

            if (condition.Id != null)
            {
                Userinfos = Userinfos.Where(p => p.UserId == condition.Id);
            }

            if (!string.IsNullOrEmpty(condition.Name) )
            {
                Userinfos = Userinfos.Where(p => p.UserName.Contains(condition.Name));
            }

            if (condition.AccountType != null)
            {
                Userinfos = Userinfos.Where(p => p.AccountType == condition.AccountType);
            }

            if (!string.IsNullOrEmpty(condition.Summary))
            {
                Userinfos = Userinfos.Where(p => p.Summary.Contains(condition.Summary));
            }

            return Userinfos;
        }

        #endregion

    }
}
