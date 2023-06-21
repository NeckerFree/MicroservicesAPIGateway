using Consumer.API.DTOs;
using Consumer.API.Entities;
using Consumer.API.Extensions;
using MassTransit;
using Parser.Common.Repositories;
using static Parser.Contracts.Contracts;

namespace Consumer.API.Endpoints
{
    public static class ClientEndpoint
    {
        //private static readonly IPublishEndpoint _publishEndpoint;
        public static void MapClientEndpoint(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Client");
            //_publishEndpoint = publishEndpoint;


            group.MapGet("/", async (IRepository<Client> _clientsRepository) =>
            {
                var clients = (await _clientsRepository.GetAllAsync())
                .Select(cl => cl.AsDto());
                return Results.Ok(clients);
            })
            .WithName("GetAllClients");

            group.MapGet("/{id}", async (Guid id, IRepository<Client> _clientsRepository) =>
            {
                Client client = await _clientsRepository.GetByIdAsync(id);
                return (client != null)
                ? Results.Ok(client.AsDto())
                : Results.NotFound();
            })
            .WithName("GetClientById");


            group.MapPost("/", async (ClientDTO clientDTO, IRepository<Client> _clientsRepository, IPublishEndpoint _publishEndpoint) =>
            {
                Client client = clientDTO.FromDto();
                await _clientsRepository.CreateAsync(client);
                await _publishEndpoint.Publish(new ClientCreated(client.Id, client.Name, client.Description, client.Address, client.Phone));
            })
            .WithName("CreateClient");

            group.MapPut("/{id}", async (Guid id, ClientDTO clientDTO, IRepository<Client> _clientsRepository, IPublishEndpoint _publishEndpoint) =>
            {
                Client client = await _clientsRepository.GetByIdAsync(id);
                if (client == null) return Results.NotFound();
                else
                {
                    //Client client = clientDTO.FromDto();
                    await _clientsRepository.UpdateAsync(id, client);
                    await _publishEndpoint.Publish(new ClientUpdated(id, client.Name, client.Description, client.Address, client.Phone));
                    return Results.NoContent();
                }
            })
            .WithName("UpdateClient");

            group.MapDelete("/{id}", async (Guid id, IRepository<Client> _clientsRepository, IPublishEndpoint _publishEndpoint) =>
            {
                Client client = await _clientsRepository.GetByIdAsync(id);
                if (client == null) return Results.NotFound();
                else
                {
                    await _clientsRepository.DeleteAsync(id);
                    await _publishEndpoint.Publish(new ClientDeleted(id));
                    return Results.NoContent();
                }
            })
            .WithName("DeleteClient");
        }
    }
}
