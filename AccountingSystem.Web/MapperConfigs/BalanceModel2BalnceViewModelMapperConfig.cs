using AccountingSyatem.Shared.Automapper;
using AccountingSystem.Services.Models;
using AccountingSystem.Web.Models;
using AutoMapper;

namespace AccountingSystem.Web.MapperConfigs
{
    public class BalanceModel2BalnceViewModelMapperConfig : EntityModelBaseMapConfig<BalanceModel, BalanceViewModel>
    {
        protected override void MapToModel(IMappingExpression<BalanceModel, BalanceViewModel> map)
        {
            map.ForAllMembers(n => n.Ignore());
            map.ForMember(x => x.Currency, y => y.MapFrom(s => s.Currency));
            map.ForMember(x => x.Amount, y => y.MapFrom(s => s.Amount));
        }

        protected override void MapToEntity(IMappingExpression<BalanceViewModel, BalanceModel> map)
        {
            map.ForAllMembers(n => n.Ignore());
        }
    }
}