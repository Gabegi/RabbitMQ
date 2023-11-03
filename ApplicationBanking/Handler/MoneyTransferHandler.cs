using RabbitMQBankingApplication.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQBankingApplication.Handler
{
    //public class MoneyTransferHandler : IRequestHandler<MoneyTransferCommandDto>
    //{
    //    private readonly IMapper _mapper;
    //    public MoneyTransferHandler(IMapper mapper)
    //    {
    //        _mapper = mapper;
    //    }

    //    public Task Handle(MoneyTransferCommandDto request, CancellationToken cancellationToken)
    //    {
    //        var moneyTransferCommand = _mapper.Map<MoneyTransferCommand>(request);
    //        return Task.CompletedTask;
    //    }

    //}
}
