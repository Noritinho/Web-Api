namespace Contracts.Communication.Users.Responses;

public class ResponseRegisteredUserJson
{
    public string Username { get; set; } = string.Empty;
    public string UserRole { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}