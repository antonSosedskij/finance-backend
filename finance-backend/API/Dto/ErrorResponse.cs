namespace finance_backend.API.Dto
{
    public class ErrorResponse
    {
        public IEnumerable<ErrorItem> Errors { get; set; }

        public sealed class ErrorItem
        {
            public string Error { get; set; }
            public string Message { get; set; }
        }
    }
}
