namespace Entities.Responses
{
    public abstract class ApiNotFoundResponse : ApiBaseResponse
    {
        public string Message { get; set; }
        public ApiNotFoundResponse(string message)
            : base(false)
        {
            Message = message;
        }
    }
}
