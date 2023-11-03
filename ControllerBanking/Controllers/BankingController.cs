using MediatR;
using Messages.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ControllerBanking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {

        private readonly ILogger<BankingController> _logger;
        private readonly IMediator _mediator;

        public BankingController(ILogger<BankingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "TransferMoney")]
        public async Task Post([FromBody] MoneyTransferCommandDto moneyTransfer)
        {
            _logger.LogInformation($"Request received from {moneyTransfer.SenderName}");

            await _mediator.Send(moneyTransfer);
        }
    }
}