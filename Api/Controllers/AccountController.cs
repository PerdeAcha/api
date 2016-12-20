using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Api.Infra.Data.Context;
using Api.ViewModels.Account;

namespace Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ApiContext _apiContext;
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, ApiContext apiContext)
        {
            _userManager = userManager;
            _apiContext = apiContext;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            EnsureDatabaseCreated(_apiContext);
            if (ModelState.IsValid) {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    return Ok();
                }
                AddErrors(result);
            }

            // If we got this far, something failed.
            return BadRequest(ModelState);
        }

        #region Helpers

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}