﻿using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Entities;

namespace Terme.Core.Domain.Masters.Repositories
{
    public interface IMasterProductPhotoCommandRepository
    {
        void Add(MasterProductPhoto masterProductPhoto);
    }
}
