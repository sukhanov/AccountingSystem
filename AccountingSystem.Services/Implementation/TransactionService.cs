using System;
using System.Collections.Generic;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Shared.Infra;

namespace AccountingSystem.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBalanceRepository _balanceRepository;
        private readonly IRateRepository _rateRepository;

        public TransactionService(ITransactionRepository transactionRepository, IBalanceRepository balanceRepository, IRateRepository rateRepository)
        {
            _transactionRepository = transactionRepository;
            _balanceRepository = balanceRepository;
            _rateRepository = rateRepository;
        }

        public string Create(NewTransaction tran)
        {
            var balance = _balanceRepository.GetById(tran.BalanceId);
            if (balance == null)
                throw new ServiceException("Balance not found");

            var rate = _rateRepository.GetByCurrencies(tran.CurrencyId, balance.CurrencyId);
            if (tran.CurrencyId == balance.CurrencyId)
                rate = new Rate { Val = 1 };
            if (rate == null)
                throw new ServiceException("Rate not found");

            var amount = tran.Amount * (decimal)rate.Val;

            if (tran.Type == (int)TransactionType.Withdraw)
                CheckAmount(balance, amount);

            tran.Amount = amount;

            return _transactionRepository.Create(tran);
        }

        public void MoveToArchive()
        {
            _transactionRepository.MoveTorchive();
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        private void CheckAmount(Balance balance, decimal amount)
        {
            if (balance.Amount < amount)
                throw new ServiceException("It is impossible to write off more than there is in the account");
        }
    }
}
