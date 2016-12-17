using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using PerdeAchaAPI.Models;

namespace PerdeAchaAPI.DataAccess
{
    public class UserDataAccess
    {
        public void Save(User user)
        {
            try
            {
                using (var context = new BaseDataAccess())
                {
                    context.User.AddOrUpdate(user);
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