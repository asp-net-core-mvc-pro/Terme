using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Resources.Resources;

namespace Terme.Endpoints.WebUI.Areas.Admin.Models.Products
{
    public class AddProductViewModel
    {
        public Master Master { get; set; }
        public long MasterId { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }


        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.ProdcutName)]
        public string Name { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Price)]
        public long Price { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Discount)]
        public long Discount { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Photo)]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Description)]
        public string Description { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.ShortDescription)]
        public string ShortDescription { get; set; }

        public List<Master> Masters { get; set; }

        public List<Category> Categories { get; set; }

        public List<SelectListItem> GetCategoriesListItems()
        {
            var result =
            Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            result.Insert(0, new SelectListItem(string.Empty, string.Empty));
            return result;

        }

        public List<SelectListItem> GetMastersListItems()
        {
            var result =
            Masters.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            }).ToList();
            result.Insert(0, new SelectListItem(string.Empty, string.Empty));
            return result;
        }
    }
}
