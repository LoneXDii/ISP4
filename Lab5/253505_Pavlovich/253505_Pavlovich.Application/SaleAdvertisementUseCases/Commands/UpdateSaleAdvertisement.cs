using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.SaleAdvertisementUseCases.Commands;

public sealed record UpdateSaleAdvertisementRequest(SaleAdvertisement advertisement) : IRequest { }

internal class UpdateSaleAdvertisementRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateSaleAdvertisementRequest>
{
    public async Task Handle(UpdateSaleAdvertisementRequest request, CancellationToken cancellationToken)
    {
        await unitOfWork.SaleAdvertisementRepository.UpdateAsync(request.advertisement, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}

