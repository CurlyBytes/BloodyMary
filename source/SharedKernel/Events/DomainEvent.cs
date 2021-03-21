using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Events {
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            this.OccurredOn = SystemClock.Now;
        }

        public DateTime OccurredOn { get; }
    }
}
