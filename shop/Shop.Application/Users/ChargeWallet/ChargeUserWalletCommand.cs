using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinal { get; private set; }
        public WalletType Type { get; set; }

        
        public ChargeUserWalletCommand(long userId, int price, string description, bool isFinal, WalletType type)
        {
            UserId = userId;
            Price = price;
            Description = description;
            IsFinal = isFinal;
            Type = type;
        }
    }
}