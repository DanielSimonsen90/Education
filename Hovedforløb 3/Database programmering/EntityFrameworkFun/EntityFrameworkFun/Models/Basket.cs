using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkFun.Models
{
    public class Basket
    {
        [Key]
        public int ID { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Basket() => Items = new HashSet<Item>();
    }
}
