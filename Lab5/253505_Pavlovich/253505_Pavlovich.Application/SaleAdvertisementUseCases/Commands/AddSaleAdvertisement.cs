using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application.SaleAdvertisementUseCases.Commands;

public sealed record AddSaleAdvertisementRequest(string name
                                                , string carModel, int carProductionYear
                                                , string salesmanName, string salesmanPhoneNumber
                                                , double cost, int? carBrandId) : IRequest<SaleAdvertisement> { }

internal class AddSaleAdvertisementRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSaleAdvertisementRequest, SaleAdvertisement>
{
    public async Task<SaleAdvertisement> Handle(AddSaleAdvertisementRequest request, CancellationToken cancellationToken)
    {
        var newAdvertisement = new SaleAdvertisement(request.name
                                    , new Car(request.carModel, request.carProductionYear)
                                    , new Salesman(request.salesmanName, request.salesmanPhoneNumber)
                                    , request.cost);

        if(request.carBrandId is not null) 
            newAdvertisement.AddToBrandAdvertisements((int)request.carBrandId);

        await unitOfWork.SaleAdvertisementRepository.AddAsync(newAdvertisement);
        await unitOfWork.SaveAllAsync();
        return newAdvertisement;
    }
}
