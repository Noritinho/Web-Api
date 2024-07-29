namespace Contracts.Communication.Users.Requests;

public class RequestChangePasswordJson
{
    public string UsernameOrEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}