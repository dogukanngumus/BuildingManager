namespace BuildingManager.API.ApiResponse
{
    public class ApiResponse<T>
    {
        public T Data  { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }    }
}