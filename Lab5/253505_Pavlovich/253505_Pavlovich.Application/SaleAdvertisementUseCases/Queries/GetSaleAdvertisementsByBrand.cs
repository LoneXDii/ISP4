using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.SaleAdvertisementUseCases.Queries;

public sealed record GetSaleAdvertisementsByBrandRequest(int Id) : IRequest<IEnumerable<SaleAdvertisement>> { }

internal class GetSaleAdvertisementsByBrandRequestHandler(IUnitOfWork unitOfWork)
                                : IRequestHandler<GetSaleAdvertisementsByBrandRequest, IEnumerable<SaleAdvertisement>>
{
    public async Task<IEnumerable<SaleAdvertisement>> Handle(GetSaleAdvertisementsByBrandRequest request,
                                                             CancellationToken cancellationToken)
    {
        return await unitOfWork.SaleAdvertisementRepository
            .ListAsync(sa => sa.CarBrandId.Equals(request.Id), cancellationToken);
    }
}
