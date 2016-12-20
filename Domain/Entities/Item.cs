using System;
using System.Collections.Generic;

namespace Domain.Entities 
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime Date { get; set; }
        public decimal Reward { get; set; }
        public string Localization { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}