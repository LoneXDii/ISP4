using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.CarBrandUseCases.Commands;

public sealed record UpdateCarBrandRequest(CarBrand brand) : IRequest { }

internal class UpdateCarBrandRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCarBrandRequest>
{
    public async Task Handle(UpdateCarBrandRequest request, CancellationToken cancellationToken)
    {
        await unitOfWork.CarBrandRepository.UpdateAsync(request.brand, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}
