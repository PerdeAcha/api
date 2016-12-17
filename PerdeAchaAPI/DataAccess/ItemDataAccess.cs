using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using PerdeAchaAPI.Models;

namespace PerdeAchaAPI.DataAccess
{
    public class ItemDataAccess
    {
        public void Save(Item item)
        {
            try
            {
                using (var context = new BaseDataAccess())
                {
                    context.Item.AddOrUpdate(item);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}