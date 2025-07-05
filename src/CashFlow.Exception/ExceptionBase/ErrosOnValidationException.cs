using System.Security.Cryptography.X509Certificates;

namespace CashFlow.Exception.ExceptionBase;
public class ErrosOnValidationException : CashFlowException
{
    public List<string> Errors { get; set; }
    public ErrosOnValidationException(List<string> ErrorMensages)
    {
        Errors = ErrorMensages;
    }
}
