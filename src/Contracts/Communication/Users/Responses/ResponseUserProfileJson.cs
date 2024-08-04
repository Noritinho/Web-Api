using Contracts.Enums;

namespace Contracts.Communication.Users.Responses;

public class ResponseUserProfileJson
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }
    public DateTimeOffset Created { get; set; }
    public string UserIdentifier { get; set; } = string.Empty;
}