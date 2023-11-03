using RabbitMQBankingApplication.Commands;
using AutoMapper;
using Messages.DTOs;

namespace RabbitMQBankingApplication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MoneyTransferCommand, MoneyTransferCommandDto>();
            CreateMap<MoneyTransferCommandDto, MoneyTransferCommand>();
        }
    }
}
