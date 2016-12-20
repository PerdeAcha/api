using System;
using Domain.Entities;
using Api.Infra.Data.Context;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AspNet.Security.OAuth.Validation;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : BaseController
    {
        private readonly ApiContext _apiContext;
        private readonly IItemAppService _itemService;
        private readonly UserManager<User> _userManager;

        public ItemController(IItemAppService itemService, ApiContext apiContext, UserManager<User> userManager)
        {
            _itemService = itemService;
            _apiContext = apiContext;
            _userManager = userManager;
        }

        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ItemViewModel model)
        {
            EnsureDatabaseCreated(_apiContext);
            var user = await _userManager.GetUserAsync(User);
            if (user == null) {
                return BadRequest();
            }
    
            if (ModelState.IsValid)
            {
                var item = new Item 
                    { 
                        Title = model.Title, 
                        Description = model.Description, 
                        Reward = Decimal.Parse(model.Reward), 
                        Localization = model.Localization,
                        Date = DateTime.Parse(model.Date),
                        UserId = user.Id
                    };
                
                _itemService.CreateItem(item);
                return Json(new {itemId= item.Id});
            }

            return Ok("error");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            EnsureDatabaseCreated(_apiContext);

            if (ModelState.IsValid)
            {
                var item = _itemService.GetById(id);
                var jsonObject = new
                {
                    title= item.Title,
                    description= item.Description,
                    localization= item.Localization,
                    reward= item.Reward
                };
                return Json(jsonObject);
            }

            return Ok("error");
        }

        [HttpGet]
        public IActionResult Get(string title)
        {
            EnsureDatabaseCreated(_apiContext);
    
            if (ModelState.IsValid)
            {
                var items = _itemService.GetItemsByTitle(title);
                return Json(items);
            }

            return Ok("error");
        }
    }
}