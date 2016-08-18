namespace Scrum.Application
{
    public interface IAuthenticationService
    {
        bool Validate(string email, string password);
    }
}