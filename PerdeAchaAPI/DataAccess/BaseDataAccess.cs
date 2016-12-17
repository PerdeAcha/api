using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PerdeAchaAPI.Models;

namespace PerdeAchaAPI.DataAccess
{
    public class BaseDataAccess : DbContext
    {
        public BaseDataAccess() : base("PerdeAcha")
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Image> Image { get; set; }


    }
}