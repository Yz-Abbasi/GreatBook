using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetById;

namespace Shop.Presentation.Facade.Sellers
{
    public class SellerFacade
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
        
        public async Task<OperationResult> EditSeller(CreateSellerCommand command)
        {
            return await _mediator.Send(command);
        }
        
        public async Task<SellerDto?> GetSellerById(long id)
        {
            return await _mediator.Send(new GetSellerByIdQuery(id));
        }
    }
}