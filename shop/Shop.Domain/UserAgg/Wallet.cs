using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;

namespace Shop.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        public Wallet(int price, string description, bool isFinal, DateTime? finalDate, WalletType type)
        {
            if(Price < 500)
                throw new InvalidDomainDataException();
                
            Price = price;
            Description = description;
            IsFinal = isFinal;
            FinalDate = finalDate;
            Type = type;
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinal { get; private set; }
        public DateTime? FinalDate { get; private set; }
        public WalletType Type { get; set; }

        public void Finally(string refCode)
        {
            IsFinal = true;
            FinalDate = DateTime.Now;
            Description +=  $"Reference code : {refCode}";
        }
        
        public void Finally()
        {
            IsFinal = true;
            FinalDate = DateTime.Now;
        }
    }
}