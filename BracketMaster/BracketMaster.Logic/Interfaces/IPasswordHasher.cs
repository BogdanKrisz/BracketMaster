namespace BracketMaster.Logic
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, byte[] salt, string providedPassword);
    }
}