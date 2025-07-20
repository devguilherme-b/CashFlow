using System.Net;

namespace CashFlow.Exception.ExceptionBase;
public abstract class CashFlowException : SystemException
{
    protected CashFlowException(string message) : base(message)
    {
        // en: this message will be the same as Message under the hood in SystemException
        // pt-BR: esta message será igual a Message por baixo dos panos em SystemException
    }
}
