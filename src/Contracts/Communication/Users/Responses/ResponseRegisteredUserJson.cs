using Contracts.Enums;

namespace Contracts.Communication.Users.Responses;

public class ResponseRegisteredUserJson
{
    public string Username { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }
    public string Token { get; set; } = string.Empty;
}