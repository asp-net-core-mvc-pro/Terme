using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Framework.Queries;

namespace Terme.Core.ApplicationServices.Masters.Queries
{
    public class AllMasterProductPhotoQueryHandler : IQueryHandler<AllMasterProductPhotoQuery, List<MasterProductPhoto>>
    {
        private readonly IMasterProductPhotoQueryRepository masterProductPhotoQueryRepository;

        public AllMasterProductPhotoQueryHandler(IMasterProductPhotoQueryRepository masterProductPhotoQueryRepository)
        {
            this.masterProductPhotoQueryRepository = masterProductPhotoQueryRepository;
        }
        public List<MasterProductPhoto> Handle(AllMasterProductPhotoQuery query)
        {
            return masterProductPhotoQueryRepository.GetAll();
        }
    }
}
