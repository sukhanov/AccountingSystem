using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccountingSyatem.Shared.Automapper;
using AccountingSystem.Services.Models;
using AccountingSystem.Shared.Infra;
using AccountingSystem.Web.Models;
using AutoMapper;

namespace AccountingSystem.Web.MapperConfigs
{
    public class Tr2TrGridItemModelMapperConfig : EntityModelBaseMapConfig<TransactionTableModel, TransactionGridItemViewModel>
    {
        protected override void MapToModel(IMappingExpression<TransactionTableModel, TransactionGridItemViewModel> map)
        {
            map.ForAllMembers(n => n.Ignore());
            map.ForMember(x => x.Type, y => y.MapFrom(s => Enum.GetName(typeof(TransactionType), s.TypeDisplay)));
            map.ForMember(x => x.Amount, y => y.MapFrom(s => s.Amount.ToString("N2")));
            map.ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("g")));
            map.ForMember(x => x.Client, y => y.MapFrom(s => s.Client));
            map.ForMember(x => x.ClientTo, y => y.MapFrom(s => s.ClientTo));
            map.ForMember(x => x.Currency, y => y.MapFrom(s => s.Currency));
            map.ForMember(x => x.Archive, y => y.MapFrom(s => s.Archive));
            map.ForMember(x => x.ArchiveDatetime, y => y.MapFrom(s => GetArchiveDateTime(s.ArchiveDatetime)));
        }

        protected override void MapToEntity(IMappingExpression<TransactionGridItemViewModel, TransactionTableModel> map)
        {
            map.ForAllMembers(n => n.Ignore());
        }

        private string GetArchiveDateTime(DateTime? archiveDatetime)
        {
            return archiveDatetime.HasValue ? archiveDatetime.Value.ToString("g") : string.Empty;
        }
    }
}