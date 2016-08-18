using Scrum.Application.Commands;

namespace Scrum.Application
{
    public interface IRegistrationService
    {
        void Register(RegisterCommand registerCommand);
    }
}