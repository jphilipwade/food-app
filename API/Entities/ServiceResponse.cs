namespace API.Entities;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
    public string Message { get; set; } = string.Empty;
}