using Identity.Api.Entities;

namespace Identity.Api.Interfaces
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegistrationModel registrationModel, string role);
        Task<(int, string)> Login(Login model);
    }
}
