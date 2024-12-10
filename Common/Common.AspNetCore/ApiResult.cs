namespace Common.AspNetCore
{
    public class ApiResult
    {
        public bool IsSuccessful { get; set; }
        public MetaData MetaData { get; set; }
    }
    
    public class ApiResult<TData>
    {
        public bool IsSuccessful { get; set; }
        public TData Data { get; set; }
        public MetaData MetaData { get; set; }
    }
}