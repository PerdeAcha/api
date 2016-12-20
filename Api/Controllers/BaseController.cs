using Microsoft.AspNetCore.Mvc;
using Api.Infra.Data.Context;

namespace Api.Controllers
{
    public class BaseController : Controller
    {
        private static bool _databaseChecked;
        internal static void EnsureDatabaseCreated(ApiContext context) {
            if (!_databaseChecked) {
                _databaseChecked = true;
                context.Database.EnsureCreated();
            }
        }
    }
}