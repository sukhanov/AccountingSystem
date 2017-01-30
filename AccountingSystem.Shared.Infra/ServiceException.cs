using System;

namespace AccountingSystem.Shared.Infra
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}