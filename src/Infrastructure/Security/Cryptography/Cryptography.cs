using Domain.Security.Cryptography;

namespace Infrastructure.Security.Cryptography;

public class Cryptography : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        
        return passwordHash;
    }
    
    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}