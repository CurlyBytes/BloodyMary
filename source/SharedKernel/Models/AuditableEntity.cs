using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Models
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; } = SystemClock.Now;

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; } = SystemClock.Now;

        public string LastModifiedBy { get; set; }
    }
}
