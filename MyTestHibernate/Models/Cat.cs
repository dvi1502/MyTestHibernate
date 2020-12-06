using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestHibernate.Models
{
    [Class]
    [Table("dbo.cat")]
    public class Cat
    {
        [Id(0, Name = "Id")]
        [Generator(1, Class = "native")]
        public virtual string Id { get; set; }

        [Property]
        public virtual string Name { get; set; }

        [Property]
        public virtual char Sex { get; set; }

        [Property]
        public virtual float Weight { get; set; }
    }
}
