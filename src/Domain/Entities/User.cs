using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class User : BaseAuditableEntity
{
    public Guid UserIdentifier { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }
}