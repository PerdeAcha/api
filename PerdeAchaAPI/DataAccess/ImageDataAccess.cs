using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using PerdeAchaAPI.Models;

namespace PerdeAchaAPI.DataAccess
{
    public class ImageDataAccess
    {
        public void Save(Image image)
        {
            try
            {
                using (var context = new BaseDataAccess())
                {
                    context.Image.AddOrUpdate(image);
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