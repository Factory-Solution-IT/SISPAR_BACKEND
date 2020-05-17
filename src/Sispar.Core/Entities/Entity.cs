using System;

namespace Sispar.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    }
}
