using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Sequence { get; private set; }

        public ProductImage(string imageName, int sequence)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));

            ImageName = imageName;
            Sequence = sequence;
        }

    }
}