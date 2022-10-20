using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkFun.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public float Cost { get; set; } = 0;

        public Item() => Baskets = new HashSet<Basket>();
        public Item(string title, float cost, string description) : this()
        {
            Title = title;
            Cost = cost;
            Description = description;
        }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
