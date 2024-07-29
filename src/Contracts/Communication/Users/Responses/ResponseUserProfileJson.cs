namespace Contracts.Communication.Users.Responses;

public class ResponseUserProfileJson
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserRole { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; }
    public string UserIdentifier { get; set; } = string.Empty;
}