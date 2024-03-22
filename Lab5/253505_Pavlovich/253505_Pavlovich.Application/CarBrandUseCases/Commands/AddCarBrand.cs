using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.CarBrandUseCases.Commands;

public sealed record AddCarBrandRequest(string name, string description) : IRequest<CarBrand> { }

internal class AddCarBrandRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCarBrandRequest, CarBrand>
{
    public async Task<CarBrand> Handle(AddCarBrandRequest request, CancellationToken cancellationToken)
    {
        var newBrand = new CarBrand(request.name, request.description);
        await unitOfWork.CarBrandRepository.AddAsync(newBrand);
        await unitOfWork.SaveAllAsync();
        return newBrand;
    }
}
