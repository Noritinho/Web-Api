using Contracts.Enums;

namespace Contracts.Communication.Users.Responses;

public class ResponseShortUserProfile
{
    public string Username { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }
}