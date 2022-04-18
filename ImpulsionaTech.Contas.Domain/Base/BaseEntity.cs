using ImpulsionaTech.Contas.Domain.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Contas.Domain.Base
{
    public class BaseEntity
    {
        public Status Status { get; set; }
        public virtual void Update(Status status)
        {
            this.Status = status;
        }
    }
}
