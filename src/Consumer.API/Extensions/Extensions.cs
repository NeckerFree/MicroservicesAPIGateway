using Consumer.API.DTOs;
using Consumer.API.Entities;

namespace Consumer.API.Extensions
{
    public static class Extensions
    {
        public static ClientDTO AsDto(this Client client)
        {
            return new ClientDTO(client.Id, client.Name, client.Description, client.Address, client.Phone);
        }

        public static Client FromDto(this ClientDTO clientDTO)
        {
            return new Client()
            {
                Id = clientDTO.Id,
                Address = clientDTO.Address,
                Description = clientDTO.Description,
                Name = clientDTO.Name,
                Phone = clientDTO.Phone,
                Created=DateTimeOffset.Now,
            };
        }
    }
}
