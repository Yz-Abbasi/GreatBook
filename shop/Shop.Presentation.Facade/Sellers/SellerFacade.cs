using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetByFilter;
using Shop.Query.Sellers.GetById;
using Shop.Query.Sellers.GetByUserId;

namespace Shop.Presentation.Facade.Sellers
{
    public class SellerFacade : ISellerFacade
    {
        private readonly IMediator _mediator;

        public SellerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
        {
            return await _mediator.Send(command);
        }
        
        public async Task<OperationResult> EditSeller(EditSellerCommand command)
        {
            return await _mediator.Send(command);
        }
        
        public async Task<SellerDto?> GetSellerById(long id)
        {
            return await _mediator.Send(new GetSellerByIdQuery(id));
        }
        
        public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
        {
            return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
        }

        public async Task<SellerDto?> GetSellerByUserId(long userId)
        {
            return await _mediator.Send(new GetSellerByUserIdQuery(userId));
        }
    }
}