using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Commands;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Framework.Commands;
using Terme.Framework.Resources;

namespace Terme.Core.ApplicationServices.Masters.Commands
{
    public class AddMasterProductPhotoCommandHandler : CommandHandler<AddMasterProductPhotoCommand>
    {
        private readonly IMasterProductPhotoCommandRepository _commandRepository;
        public AddMasterProductPhotoCommandHandler(IResourceManager resourceManager, IMasterProductPhotoCommandRepository commandRepository) : base(resourceManager)
        {
            _commandRepository = commandRepository;
        }

        public override CommandResult Handle(AddMasterProductPhotoCommand command)
        {
            if (IsValid(command))
            {
                MasterProductPhoto master = new MasterProductPhoto
                {
                  Photo = command.Photo,
                  MasterProducts = command.MasterProducts
                };
                _commandRepository.Add(master);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddMasterProductPhotoCommand command)
        {
            return true;
        }
    }
}
