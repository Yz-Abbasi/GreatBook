using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.FinalizeOrder
{
    public class FinalizeOrderCommandHandler : IBaseCommandHandler<FinalizeOrderCommand>
    {
        public Task<OperationResult> Handle(FinalizeOrderCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}