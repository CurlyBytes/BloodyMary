Domain project - NO other depenency other than sharedkernel

SharedKernel - Utility class for DDD

- Use system clock for centrlized datetime.utc value with static class
- avoid any 3rd party library

ValueObjects

- Must not use reflection
- Must have CheckBussinessRules if custom ValueObjects
- Use https://github.com/kgrzybek/sample-dotnet-core-cqrs-api for value objects
  and agree not to use

Entity - Must use GUID must have auditable entity attach

Events -
combine clean architecture without using mediatr in the domain
and add events via events from kramil russian developer
           //clean architecture 
            //DomainEvents.AddDomainEvent(new CreateWarehouseEvent(this));

            // kamilgrzybek
            this.AddDomainEvent(new CreateWarehouseEvent(this));

Referrence Kamil Grzybek

TASK:

- check referrence of class enumration why not use directly enmum
