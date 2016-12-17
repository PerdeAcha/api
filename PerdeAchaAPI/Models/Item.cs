using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using PerdeAchaAPI.Models.Enum;

namespace PerdeAchaAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Reward { get; set; }
        public ItemType Type { get; set; }
        public string Localization { get; set; }
        public List<Image> Images { get; set; }

    }
}