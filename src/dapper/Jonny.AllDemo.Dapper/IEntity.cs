using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.Dapper
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
