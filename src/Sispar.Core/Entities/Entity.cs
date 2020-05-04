using System;

namespace Sispar.Core.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    }
}
