using Identity.Api.Entities;
using Identity.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.EndPoints
{
    public static class SecurityEndPoint
    {

        public static void MapSecurityEndPoint(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("api/auth");
            group.MapPost("/login", [AllowAnonymous] async ([FromBody] Login login, IAuthService authService) =>
            {
                var (status, message) = await authService.Login(login);
                if (status == 0)
                    return Results.BadRequest(message);
                return Results.Ok(message);
            });
            group.MapPost("/registeration", async ([FromBody]  RegistrationModel regisModel, IAuthService authService) =>
            {
                var (status, message) = await authService.Registeration(regisModel, "GeneralUser");
                if (status == 0)
                {
                    return Results.BadRequest(message);
                }
                return Results.Created($"/register/{regisModel.Username}", regisModel);
            }).RequireAuthorization();
            
        }
    }
}
