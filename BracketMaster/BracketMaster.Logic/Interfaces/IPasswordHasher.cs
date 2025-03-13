namespace BracketMaster.Logic
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string givenPassword, string storedHash);
    }
}