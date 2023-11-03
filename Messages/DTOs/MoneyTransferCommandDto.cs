using MediatR;

namespace Messages.DTOs
{
    public class MoneyTransferCommandDto : IRequest
    {
        public int TransferAmount { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
    }
}
