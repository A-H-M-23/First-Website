namespace DataLayer
{
    public interface ILoginRepository
    {
        bool IsUserExist(string username , string password);
    }
}
