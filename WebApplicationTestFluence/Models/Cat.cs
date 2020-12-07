using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestHibernate.Models
{
    public class Cat
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual char Sex { get; set; }

        public virtual float Weight { get; set; }
    }
    public class CatMap : ClassMap<Cat>
    {
        public CatMap()
        {

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Sex);
            Map(x => x.Weight);

        }
    }
}
