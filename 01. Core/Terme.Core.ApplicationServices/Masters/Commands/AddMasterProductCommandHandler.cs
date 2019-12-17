using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Commands;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Core.Domain.Photos.Entities;
using Terme.Core.Resources.Resources;
using Terme.Framework.Commands;
using Terme.Framework.Resources;

namespace Terme.Core.ApplicationServices.Masters.Commands
{
    public class AddMasterProductCommandHandler: CommandHandler<AddMasterProductCommand>
    {
        private readonly IMasterProductCommandRepository _commandRepository;
        public AddMasterProductCommandHandler(IResourceManager resourceManager, IMasterProductCommandRepository commandRepository) : base(resourceManager)
        {
            _commandRepository = commandRepository;
        }

        public override CommandResult Handle(AddMasterProductCommand command)
        {
            if (IsValid(command))
            {
                MasterProduct master = new MasterProduct
                {
                    Name = command.Name,
                    Description = command.Description,
                    ShortDescription = command.ShortDescription,
                    Discount = command.Discount,
                    CategoryId = command.CategoryId,
                    MasterId = command.MasterId,
                    Price = command.Price
                };
                _commandRepository.Add(master);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddMasterProductCommand command)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(command.Name))
            {
                AddError(SharedResource.Required, SharedResource.ProdcutName);
                isValid = false;
            }
            return isValid;
        }
    }
}
