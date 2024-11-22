using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {
        }

        public UserAddress GetUserAddressById(long addressId)
        {
            throw new NotImplementedException();
        }
    }
}