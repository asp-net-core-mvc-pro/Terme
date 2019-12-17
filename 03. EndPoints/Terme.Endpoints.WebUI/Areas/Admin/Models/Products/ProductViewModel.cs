using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Core.Domain.Photos.Entities;
using Terme.Infrastructures.Data.SqlServer.Masters.Repositories;

namespace Terme.Endpoints.WebUI.Areas.Admin.Models.Products
{
    public class ProductViewModel
    {
        public MasterProduct MasterProducts { get; set; }
        public long MasterProductsId { get; set; }
        public Photo Photo { get; set; }
        public long PhotoId { get; set; }

    }
}
