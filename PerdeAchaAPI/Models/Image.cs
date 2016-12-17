using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerdeAchaAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string Data { get; set; }
    }
}