using Domain.Security.Cryptography;

namespace Infrastructure.Security;

public class Cryptography : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        return passwordHash;
    }
}