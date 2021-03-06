﻿using System;
using AccountingSystem.Models;
using AccountingSystem.Shared.Infra;
using AccountingSystem.Web.Models;
using AutoMapper;

namespace AccountingSystem.Web
{
    public class AutomapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionGridItemViewModel>()
                    .ForMember(x => x.Type, y => y.MapFrom(s => Enum.GetName(typeof(TransactionType), s.TypeDisplay)))
                    .ForMember(x => x.Amount, y => y.MapFrom(s => s.Amount.ToString("N2")))
                    .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("g")))
                    .ForMember(x => x.Client, y => y.MapFrom(s => s.ClientName))
                    .ForMember(x => x.Currency, y => y.MapFrom(s => s.Currency))
                    .ForMember(x => x.ArchiveDatetime, y => y.MapFrom(s => GetArchiveDateTime(s.ArchiveDatetime)));

                cfg.CreateMap<NewTransactionModel, NewTransaction>()
                    .ForMember(x => x.ClientId, y => y.MapFrom(s => s.Client))
                    .ForMember(x => x.BalanceId, y => y.MapFrom(s => s.Balance))
                    .ForMember(x => x.CurrencyId, y => y.MapFrom(s => s.Currency))
                    .ForMember(x => x.Type, y => y.MapFrom(s => s.Type))
                    .ForMember(x => x.Amount, y => y.MapFrom(s => s.Amount));

                cfg.CreateMap<Balance, BalanceViewModel>()
                    .ForMember(x => x.Currency, y => y.MapFrom(s => s.Currency))
                    .ForMember(x => x.Amount, y => y.MapFrom(s => s.Amount));
            });
        }

        private static string GetArchiveDateTime(DateTime? archiveDatetime)
        {
            return archiveDatetime?.ToString("g") ?? string.Empty;
        }
    }
}