using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByFilter
{
    public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
    {
        public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
        {
        }
    }
}