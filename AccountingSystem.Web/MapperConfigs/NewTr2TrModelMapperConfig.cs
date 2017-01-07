using System;
using AccountingSyatem.Shared.Automapper;
using AccountingSystem.Services.Models;
using AccountingSystem.Web.Models;
using AutoMapper;

namespace AccountingSystem.Web.MapperConfigs
{
    public class NewTr2TrModelMapperConfig : EntityModelBaseMapConfig<NewTransaction, TransactionModel>
    {
        protected override void MapToModel(IMappingExpression<NewTransaction, TransactionModel> map)
        {
            map.ForAllMembers(n => n.Ignore());
            map.ForMember(x => x.ClientId, y => y.MapFrom(s => s.Client));
            map.ForMember(x => x.CurrencyId, y => y.MapFrom(s => s.Currency));
            map.ForMember(x => x.Type, y => y.MapFrom(s => s.Type));
            map.ForMember(x => x.Amount, y => y.MapFrom(s => s.Amount));
        }

        protected override void MapToEntity(IMappingExpression<TransactionModel, NewTransaction> map)
        {
            map.ForAllMembers(n => n.Ignore());
        }
    }
}