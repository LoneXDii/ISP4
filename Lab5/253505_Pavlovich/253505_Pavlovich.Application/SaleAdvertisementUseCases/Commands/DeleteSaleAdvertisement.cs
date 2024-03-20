using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.SaleAdvertisementUseCases.Commands;

public sealed record DeleteSaleAdvertisementRequest(SaleAdvertisement advertisement) : IRequest { }

internal class DeleteSaleAdvertisementRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteSaleAdvertisementRequest>
{
    public async Task Handle(DeleteSaleAdvertisementRequest request, CancellationToken cancellationToken)
    {
        await unitOfWork.SaleAdvertisementRepository.DeleteAsync(request.advertisement, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}
