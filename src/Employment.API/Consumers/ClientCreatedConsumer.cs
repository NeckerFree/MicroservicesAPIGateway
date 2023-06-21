using Employment.API.Entities;
using MassTransit;
using Parser.Common.Repositories;
using static Parser.Contracts.Contracts;

namespace Employment.API.Consumers
{
    public class ClientCreatedConsumer : IConsumer<ClientCreated>
    {
        private readonly IRepository<Client> _repository;

        public ClientCreatedConsumer(IRepository<Client> _repository)
        {
            this._repository = _repository;
        }
        public async Task Consume(ConsumeContext<ClientCreated> context)
        {
            var message = context.Message;
            var client =await _repository.GetByIdAsync(message.Id);
            if (client != null)
            {
                return;
            }
            else
            {
                client = new Client()
                {
                    Id = message.Id,
                    Address = message.Address,
                    Description = message.Description,
                    Name = message.Name,
                    Phone = message.Phone,
                };
                await _repository.CreateAsync(client);
            }
        }
    }
}
