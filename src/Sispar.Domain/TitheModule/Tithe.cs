using Sispar.Domain.BaseModule;
using Sispar.Domain.TitherModule;
using System;

namespace Sispar.Domain.TitheModule
{
    public class Tithe : Entity
    {
        public decimal ValueContribution { get; set; }
        public DateTime DateContribution { get; set; }
        public Guid TitherId { get; set; }

        public virtual Tither Tither { get; set; }
    }
}