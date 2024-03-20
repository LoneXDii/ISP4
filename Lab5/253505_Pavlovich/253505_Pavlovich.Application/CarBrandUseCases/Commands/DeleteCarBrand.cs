using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.CarBrandUseCases.Commands;

public sealed record DeleteCarBrandRequest(CarBrand brand) : IRequest { }

internal class DeleteCarBrandRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCarBrandRequest>
{
    public async Task Handle(DeleteCarBrandRequest request, CancellationToken cancellationToken)
    {
        await unitOfWork.CarBrandRepository.DeleteAsync(request.brand, cancellationToken);
        await unitOfWork.SaveAllAsync();
    }
}

