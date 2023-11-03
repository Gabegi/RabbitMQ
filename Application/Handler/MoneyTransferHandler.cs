using ApplicationLayer.Commands;
using MediatR;

namespace ApplicationLayer.Handler
{
    public class MoneyTransferHandler : IRequestHandler<MoneyTransferCommand>
    {
        public Task Handle(MoneyTransferCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
