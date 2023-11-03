
# RabbitMQ

## Rabbit MQ Introduction


[RabbitMQ for beginners](https://www.cloudamqp.com/blog/part1-rabbitmq-for-beginners-what-is-rabbitmq.html)


## Publish Subscribe Pattern

- One publisher, 1+ Subscribers
- One separate queue for each sub
- Each sub gets same message

## RabbitMq

We are going to use the publisher/ subscriber pattern.
install RabbitMQ.Client

Some terms:

- Connection
- Channel
- Message
- BasicPublish
- Exchanges
- Bindings

## Steps

Prepare 

- Create two queues
- Bind the queues to the fanout exchange

Create the publisher app
- Add connection
- Create channel
- Create a fanout exchange
- Create queues
- Create message
- Publish message
- Close channel and connection (use using)

Create the subscriber app
- Add connection
- Create channel
- Bind queues to the exchange
- Create consumer
- Receive message
- Subscribe to the queue
- Close channel and connection (use using)


[Programming RabbitMQ in C#](https://www.infoworld.com/article/3200210/how-to-work-with-rabbitmq-in-c.html)
[RabbitMQ Exchanges in C#](https://medium.com/@bakhtmunir/rabbitmq-exchanges-in-c-8b3202fb3ab0)
[Publish/Subscribe](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)
[Fanout Exchange in AMQP – RabbitMQ (Publish/Subscribe)](https://jstobigdata.com/rabbitmq/fanout-exchange-in-amqp-rabbitmq/)


## Clean Architecture Principles
Promote separation of concern and maintanability.


### Services Layer
- At the centre of the diagram
- Orchestrates interactions between the different layers of the application
- Agnostic about delivery mechanism, DB, external components
- Focuses on business logic


### Application Layer
- Command/ Queries
- App specific use-cases
- Bridge between presentation layer and domain layer (outer and inner)
- Includes tasks such as validation, authentication and authorisation

### Domain Layer
- Defines entities, value objects, business rules that represent core concepts and logic of the app
- Isolated from database or UI

### Infa/Data Layer
- Data Repositories, Database access, data storage
- Interaction with external services such as DBs

### Services Layer

## Code Implementation



## Controller
In our case the user interacts with API directly.

## AutoMapper

To map our DTO to our domain objects we are going to use AutoMapper
[What is AutoMapper?](https://docs.automapper.org/en/stable/Getting-started.html)
[Create Data Transfer Objects (DTOs)](https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5)


- Dependency Injection AutoMappper DotNet 6 API Project

#1 Use the IMapper mapper in the constructor
#2 Install AutoMapper Dependency Injection package
#3 Create Mapping Profile
#4 in Program add builder.Services.AddAutoMapper(typeof(MappingProfile));


Error:
 System.InvalidOperationException: Unable to resolve service for type 'AutoMapper.IMapper' while attempting to activate 'ControllerBanking.Controllers.BankingController'.

Solution:
Make sure the dto is well mapped to the domain object by doing
```

public ProductDto MapProductToDto(Product product)
    {
        return _mapper.Map<ProductDto>(product);
    }
 ```

## MediatR

Our app will be using the CQRS pattern where commands and queries are split
[CQRS pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)

Error:
System.InvalidOperationException: No service for type 'MediatR.IRequestHandler`1[Application.Commands.MoneyTransferCommand]' has been registered.

Solution:


- MediatR Dependency Injection





Errors
System.InvalidOperationException: No service for type 'MediatR.IRequestHandler`1[ControllerBanking.DTOs.MoneyTransferCommandDto]' has been registered.

Solution



Errors

 No job functions found. Try making your job classes and methods public. If you're using binding extensions (e.g. Azure Storage, ServiceBus, Timers, etc.) make sure you've called the registration method for the extension(s) in your startup code (e.g. builder.AddAzureStorage(), builder.AddServiceBus(), builder.AddTimers(), etc.).
For detailed output, run func with --verbose flag.

Solution


## DTOs
We are using Data transfer object DTOs (Data transfer objects) to safely separate data from client to data layer.
Our controllers will therefore return contracts (here DTOs by lack of presentation layer).
Domain objects will be used to interact with RabbitMQ

[Create Data Transfer Objects (DTOs)](https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5)








## UI Management Interface

- runs on port 15672: http://localhost:15672/
- Connection tab: appears when app running, can see connection created
- PW: guest, UserName: guest


## Integrate with Azure

[How to integrate Service Bus with RabbitMQ](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-integrate-with-rabbitmq)