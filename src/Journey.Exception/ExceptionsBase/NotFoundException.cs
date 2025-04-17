using System.Net;

namespace Journey.Exception.ExceptionsBase;

public class NotFoundException : JourneyException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
