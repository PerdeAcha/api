using System;
using Domain.Entities;
using Api.Infra.Data.Context;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : BaseController
    {
        private readonly ApiContext _apiContext;
        private readonly IItemAppService _itemService;

        public ItemController(IItemAppService itemService, ApiContext apiContext)
        {
            _itemService = itemService;
            _apiContext = apiContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ItemViewModel model)
        {
            EnsureDatabaseCreated(_apiContext);
    
            if (ModelState.IsValid)
            {
                var item = new Item 
                    { 
                        Title = model.Title, 
                        Description = model.Description, 
                        Reward = Decimal.Parse(model.Reward), 
                        Localization = model.Localization
                    };
                
                _itemService.CreateItem(item);
            }

            return Ok("error");
        }
    }
}