using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        private Seller()
        {
            
        }
        public Seller(long userId, string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);

            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus SellerStatus { get; private set; }
        public DateTime LastUpdate { get; internal set; }
        public List<SellerInventory> Inventories { get; private set; }


        public void ChangeStatus(SellerStatus status)
        {
            SellerStatus = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public void AddInventory(SellerInventory inventory)
        {
            if(Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("This product has already been added to inventory!");

            Inventories.Add(inventory);
        }
        
        public void EditInventory(SellerInventory newInventory)
        {
            var selectedInventory = Inventories.FirstOrDefault(f => f.ProductId == newInventory.Id);
            if(selectedInventory == null)
                return ;

            Inventories.Remove(selectedInventory);
            Inventories.Add(newInventory);
        }
        
        public void DeleteInventory(long inventoryId)
        {
            var selectedInventory = Inventories.FirstOrDefault(f => f.ProductId == inventoryId);
            if(selectedInventory == null)
                throw new InvalidDomainDataException("Inventory doesn't exist!");
            
            Inventories.Remove(selectedInventory);
        }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if(IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("National code is invalid!");
        }
    }
}