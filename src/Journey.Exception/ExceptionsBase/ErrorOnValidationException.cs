using System.Net;

namespace Journey.Exception.ExceptionsBase;

public class ErrorOnValidationException : JourneyException
{
    private readonly IList<string> _errors;

    public ErrorOnValidationException(IList<string> messages) : base(string.Empty)
    {
        _errors = new List<string>(messages);
    }

    public override IList<string> GetErrorMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
