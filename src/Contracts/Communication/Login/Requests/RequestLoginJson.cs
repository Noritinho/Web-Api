namespace Contracts.Communication.Login.Requests;

public class RequestLoginJson
{
    public string UsernameOrEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}