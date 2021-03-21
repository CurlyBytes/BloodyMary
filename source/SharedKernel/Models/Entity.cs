using SharedKernel.Events;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Models {
  public abstract class Entity {

    private List<DomainEvent> _domainEvents;

    /// <summary>
    /// Domain events occurred.
    /// </summary>
    public IReadOnlyCollection<DomainEvent> DomainEvents =>
        _domainEvents?.AsReadOnly();

    /// <summary>
    /// Add domain event.
    /// </summary>
    /// <param name="domainEvent"></param>
    protected void AddDomainEvent(DomainEvent domainEvent) {
      _domainEvents = _domainEvents ?? new List<DomainEvent>();
      this._domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clear domain events.
    /// </summary>
    public void ClearDomainEvents() { _domainEvents?.Clear(); }

    protected static void CheckRule(IBusinessRule rule) {
      if (rule.IsBroken()) {
        throw new BusinessRuleValidationException(rule);
      }
    }
  }
}
