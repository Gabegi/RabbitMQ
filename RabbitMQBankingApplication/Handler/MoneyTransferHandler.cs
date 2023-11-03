using RabbitMQBankingApplication.Commands;
using AutoMapper;
using MediatR;
using Messages.DTOs;
using RabbitMQBus;

namespace RabbitMQBankingApplication.Handler
{
    public class MoneyTransferHandler : IRequestHandler<MoneyTransferCommandDto>
    {
        private readonly IMapper _mapper;
        private readonly IRabbitMqBus _rabbitMqBus;

        public MoneyTransferHandler(IMapper mapper, IRabbitMqBus rabbitMqBus)
        {
            _mapper = mapper;
            _rabbitMqBus = rabbitMqBus;
        }

        public async Task Handle(MoneyTransferCommandDto request, CancellationToken cancellationToken)
        {
            var moneyTransferCommand = _mapper.Map<MoneyTransferCommand>(request);

            await _rabbitMqBus.Publish(moneyTransferCommand);
        }

    }
}
