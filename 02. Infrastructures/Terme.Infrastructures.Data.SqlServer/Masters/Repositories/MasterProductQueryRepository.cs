using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Repositories
{
    public class MasterProductQueryRepository : IMasterProductQueryRepository
    {
        private readonly TermeDbContext _termeDbContext;

        public MasterProductQueryRepository(TermeDbContext termeDbContext)
        {
            _termeDbContext = termeDbContext;
        }
        public List<MasterProduct> GetAll()
        {
            return _termeDbContext.MasterProducts.AsNoTracking().ToList();
        }
    }
}
