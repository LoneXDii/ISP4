using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.CarBrandUseCases.Queries;

public sealed record GetCarBrandsRequest() : IRequest<IEnumerable<CarBrand>> { }

internal class GetCarBrandsRequestHandler(IUnitOfWork unitOfWork) 
                        : IRequestHandler<GetCarBrandsRequest, IEnumerable<CarBrand>>
{
    public async Task<IEnumerable<CarBrand>> Handle(GetCarBrandsRequest request,
                                                CancellationToken cancellationToken)
    {
        return await unitOfWork.CarBrandRepository.ListAllAsync(cancellationToken);
    }
}
