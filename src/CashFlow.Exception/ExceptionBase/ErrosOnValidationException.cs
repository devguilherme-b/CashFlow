using System.Net;

namespace CashFlow.Exception.ExceptionBase;
public class ErrosOnValidationException : CashFlowException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrosOnValidationException(List<string> ErrorMensages) : base(string.Empty)
    {
        _errors = ErrorMensages;
    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
