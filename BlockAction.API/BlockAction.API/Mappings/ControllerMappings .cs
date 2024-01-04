using AutoMapper;
using BlockAction.API.Model;
using BlockAction.API.Parameter;
using BlockAction.Repository.Dtos.DataModel;
using BlockAction.Service.Dtos.Info;
using BlockAction.Service.Dtos.ResultModel;

namespace BlockAction.API.Mappings
{
    public class ControllerMappings : Profile
    {
        public ControllerMappings()
        {
            // Parameter -> Info
            this.CreateMap<UserParameter, UserInfo>();
            this.CreateMap<UserSearchParameter, UserSearchInfo>();

            this.CreateMap<UserFundDetailParameter, UserFundDetailInfo>();
            this.CreateMap<UserFundDetailSearchParameter, UserFundDetailSearchInfo>();

            // ResultModel -> ViewModel
            this.CreateMap<UserResultModel, UserViewModel>();
            this.CreateMap<UserFundDetailResultModel, UserFundDetailViewModel>();
        }
    }
}
