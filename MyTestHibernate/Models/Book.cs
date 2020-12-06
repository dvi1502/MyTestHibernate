using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestHibernate.Models
{
    [Class]
    [Table("dbo.Book")]
    
    public class Book
    {
        [Id(0, Name = "Id")]
        [Generator(1, Class = "native")] 
        public virtual int Id { get; set; }
        
        [Property]
        public virtual string Title { get; set; }
        
        [Property] 
        public virtual string Description { get; set; }
        
    }
}
