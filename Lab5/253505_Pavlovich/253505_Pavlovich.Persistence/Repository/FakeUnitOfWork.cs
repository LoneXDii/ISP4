using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Persistence.Repository;

internal class FakeUnitOfWork : IUnitOfWork
{
    private readonly Lazy<IRepository<CarBrand>> _brands;
    private readonly Lazy<IRepository<SaleAdvertisement>> _advertisements;

    public FakeUnitOfWork()
    {
        _brands = new(() => new FakeCarBrandRepository());
        _advertisements = new(() => new FakeSaleAdvertisementRepository());
    }

    public IRepository<CarBrand> CarBrandRepository => _brands.Value;
    public IRepository<SaleAdvertisement> SaleAdvertisementRepository => _advertisements.Value;
    public Task SaveAllAsync()
    {
        throw new NotImplementedException();
    }
    public Task DeleteDataBaseAsync()
    {
        throw new NotImplementedException();
    }
    public Task CreateDataBaseAsync()
    {
        throw new NotImplementedException();
    }
}
