
namespace RabbitMQBankingApplication.Commands
{
    public class MoneyTransferCommand
    {
        public int TransferAmount { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
        public int TransactionId { get; set; }
    }
}
