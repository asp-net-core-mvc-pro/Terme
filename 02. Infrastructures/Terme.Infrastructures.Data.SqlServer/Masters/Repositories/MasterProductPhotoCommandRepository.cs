using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Repositories
{
    public class MasterProductPhotoCommandRepository : IMasterProductPhotoCommandRepository
    {
        private readonly TermeDbContext termeDbContext;

        public MasterProductPhotoCommandRepository(TermeDbContext termeDbContext)
        {
            this.termeDbContext = termeDbContext;
        }
        public void Add(MasterProductPhoto masterProductPhoto)
        {
            termeDbContext.MasterProductPhotos.Add(masterProductPhoto);
            termeDbContext.SaveChanges();
        }
    }
}
