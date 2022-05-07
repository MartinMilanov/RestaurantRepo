namespace Restaurant.Web.Models.Response
{
    public class Response<T> : IResponse<T>
    {
        public bool HasException { get; set; }
        public string ExceptionMessage { get; set; }
        public T Data { get; set; }

        public Response(bool hasException, string exceptionMessage, T data)
        {
            HasException = hasException;
            ExceptionMessage = exceptionMessage;
            Data = data;
        }
    }
}
