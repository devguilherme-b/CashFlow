namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{
    public List<string> ErrorMesssages { get; set; }

    public ResponseErrorJson(string errorMensage)
    {
        ErrorMesssages = new List<string> { errorMensage };
    }

    public ResponseErrorJson(List<string> errorMensage)
    {
        ErrorMesssages = errorMensage;
    }
}
