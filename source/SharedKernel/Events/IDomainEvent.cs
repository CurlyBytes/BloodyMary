using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Events
{
public interface IDomainEvent
{
    DateTime OccurredOn {
        get;
    }
}
}
