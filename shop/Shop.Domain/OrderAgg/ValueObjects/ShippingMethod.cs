using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod : ValueObject
    {
        public ShippingMethod(string shippimngType, int shippingCost)
        {
            ShippimngType = shippimngType;
            ShippingCost = shippingCost;
        }

        public string ShippimngType { get; private set; }
        public int ShippingCost { get; private set; }
    }
}