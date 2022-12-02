namespace LiveApp.Services
{
    public interface IUserServices
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}