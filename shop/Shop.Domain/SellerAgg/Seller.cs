using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus SellerStatus { get; private set; }
        public DateTime LastUpdate { get; internal set; }
        public List<SellerInventory> Inventories { get; private set; }


        private Seller()
        {
            
        }
        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);

            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();

            if(domainService.CheckSellerInfo(this) == false)
                throw new InvalidDomainDataException("Info is invalid1");
        }


        // public void ChangeStatus(SellerStatus status)
        // {
        //     SellerStatus = status;
        //     LastUpdate = DateTime.Now;
        // }

        public void Edit(string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            if(domainService.NationalCodeExistsInDatabase(nationalCode) == true)
                throw new InvalidDomainDataException("This National has already been used before!");

            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public void AddInventory(SellerInventory inventory)
        {
            if(Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("This product has already been added to inventory!");

            Inventories.Add(inventory);
        }
        
        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var selectedInventory = Inventories.FirstOrDefault(f => f.ProductId == inventoryId);
            if(selectedInventory == null)
                throw new InvalidDomainDataException("Inventory can not be found!");

            selectedInventory.Edit(count, price, discountPercentage);
        }
        
        // public void DeleteInventory(long inventoryId)
        // {
        //     var selectedInventory = Inventories.FirstOrDefault(f => f.ProductId == inventoryId);
        //     if(selectedInventory == null)
        //         throw new InvalidDomainDataException("Inventory doesn't exist!");
            
        //     Inventories.Remove(selectedInventory);
        // }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if(IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("National code is invalid!");
        }
    }
}