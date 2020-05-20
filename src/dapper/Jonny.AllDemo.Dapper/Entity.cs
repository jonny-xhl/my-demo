using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.Dapper
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
    public class Entity : Entity<Guid>
    {
    }
}
