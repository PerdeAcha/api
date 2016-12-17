using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace PerdeAchaAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public List<Item> Itens { get; set; }
    }
}