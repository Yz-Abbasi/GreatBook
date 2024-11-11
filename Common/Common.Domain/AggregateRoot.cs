using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Common.Domain;

namespace Common.Domain
{
    public class AggregateRoot : BaseEntity
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        [NotMapped]
        public List<BaseDomainEvent> DomainEvents => _domainEvents;
        
        public void AddEvent(BaseDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveEvent(BaseDomainEvent eventItem)
        {
            _domainEvents.Remove(eventItem);
        }
        
    }
}