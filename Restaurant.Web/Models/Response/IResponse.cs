namespace Restaurant.Web.Models.Response
{
    public interface IResponse<T>
    {
        bool HasException { get; set; }
        string ExceptionMessage { get; set; }
        T Data { get; set; }
    }
}
