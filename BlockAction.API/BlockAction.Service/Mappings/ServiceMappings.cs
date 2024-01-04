using AutoMapper;
using BlockAction.Repository.Dtos.Condition;
using BlockAction.Repository.Dtos.DataModel;
using BlockAction.Service.Dtos.Info;
using BlockAction.Service.Dtos.ResultModel;

namespace BlockAction.Service.Mappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            // Info -> Condition
            this.CreateMap<UserInfo, UserCondition>();
            this.CreateMap<UserSearchInfo, UserSearchCondition>();

            this.CreateMap<UserFundDetailInfo, UserFundDetailCondition>();
            this.CreateMap<UserFundDetailSearchInfo, UserFundDetailSearchCondition>();

            // DB DataModel -> ResultModel
            this.CreateMap<Userdatainfo, UserResultModel>();
            this.CreateMap<Userfundetail, UserFundDetailResultModel>();

        }
    }
}
