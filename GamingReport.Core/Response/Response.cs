namespace GamingReport.Core;

public class ServiceResponse<T>
{
    public T? Data { get; set; }

    public ResponseStatus Status { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }

    public bool IsSuccess => Status == ResponseStatus.Succes;

    public static ServiceResponse<T> Success(T data, string message = "")
        => new() { Data = data, Status = ResponseStatus.Succes, Message = message };
    
    public static ServiceResponse<T> Error(string message, List<string> errors = null)
    => new() {Status = ResponseStatus.Error, Message = message, Errors = errors ?? new() };
    
    public static ServiceResponse<T> NotFound(string message = "Recurso não encontrado")
    => new() { Status = ResponseStatus.NotFound, Message = message };
}