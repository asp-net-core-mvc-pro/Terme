using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Repositories
{
    public class MasterProductPhotoQueryRepository : IMasterProductPhotoQueryRepository
    {
        private readonly TermeDbContext termeDbContext;

        public MasterProductPhotoQueryRepository(TermeDbContext termeDbContext)
        {
            this.termeDbContext = termeDbContext;
        }
        public List<MasterProductPhoto> GetAll()
        {
            return termeDbContext.MasterProductPhotos.AsNoTracking()
                .Include(p => p.Photo)
                .Include(p => p.MasterProducts.Category)
                .Include(p => p.MasterProducts.Master)
                .ToList();
        }

    }
}
