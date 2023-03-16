

public class ResponseModel<T>
{
    public T? Data { get; set; }

    public bool IsSuccess { get; set; } = true;

    public String Messsage { get; set; } = String.Empty;
}