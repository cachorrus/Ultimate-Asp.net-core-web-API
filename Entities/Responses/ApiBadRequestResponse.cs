namespace Entities.Responses
{
    public abstract class ApiBadRequestResponse : ApiBaseResponse
    {
        public string Message { get; set; }
        public ApiBadRequestResponse(string message)
            : base(false)
        {
            Message = message;
        }
    }
}
