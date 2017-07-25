namespace SimpleRDS.DataLayer.Business
{
    public interface IPasswordHasher<T>
    {
        string HashPassword(T salt, string password);
        bool IsValidHash(T salt, string password, string hash);
    }
}