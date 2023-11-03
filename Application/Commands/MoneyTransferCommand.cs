using MediatR;

namespace ApplicationLayer.Commands
{
    public class MoneyTransferCommand: IRequest
    {
        public int TransferAmount { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
        public int TransactionId { get; set; }
    }
}
