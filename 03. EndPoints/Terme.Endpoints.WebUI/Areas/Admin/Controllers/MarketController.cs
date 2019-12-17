using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Queries;
using Terme.Core.Domain.Masters.Commands;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Photos.Entities;
using Terme.Endpoints.WebUI.Areas.Admin.Models.Products;
using Terme.Endpoints.WebUI.FileServices;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

namespace Terme.Endpoints.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarketController : BaseController
    {
    
        public MarketController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }
        public IActionResult Index()
        {
            var allMasterProductsPhotos = _queryDispatcher.Dispatch<List<MasterProductPhoto>>(new AllMasterProductPhotoQuery());

            return View(allMasterProductsPhotos);
        }

        public IActionResult AddEditProduct() 
        {
            var model = new AddProductViewModel
            {
                Categories = _queryDispatcher.Dispatch<List<Category>>(new ParentCategoryQuery()),
                Masters = _queryDispatcher.Dispatch<List<Master>>(new AllMasterQuery())
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddEditProduct(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fileUrl = new FileSaver().Save(model.Photo);

                var masterProduct = new MasterProduct {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    MasterId = model.MasterId,
                    ShortDescription = model.ShortDescription,
                    Discount = model.Discount,
                    Price = model.Price
                };
                var photo = new Photo {
                 Url = fileUrl,
                };

                var result = _commandDispatcher.Dispatch(new AddMasterProductPhotoCommand { 
                     MasterProducts = masterProduct,
                     Photo = photo 
                });

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
                foreach (string item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}