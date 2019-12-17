using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Photos.Entities;
using Terme.Framework.Commands;

namespace Terme.Core.Domain.Masters.Commands
{
    public class AddMasterProductPhotoCommand:ICommand
    {
        public MasterProduct MasterProducts { get; set; }
        public Photo Photo { get; set; }
    }
}
