using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Persistence.Repository;

internal class FakeSaleAdvertisementRepository : IRepository<SaleAdvertisement>
{
    List<SaleAdvertisement> _advertisements;

    public FakeSaleAdvertisementRepository()
    {
        _advertisements = new List<SaleAdvertisement>();
        int k = 1;
        for (int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                var advert = new SaleAdvertisement($"Car {k++}",
                    new Car($"{i}", DateTime.Now.AddYears(-Random.Shared.Next(40)).Year),
                    new Salesman($"j", $"+{Random.Shared.Next((int)1e8, (int)1e9)}"),
                    Random.Shared.Next(20000, 200000));
                advert.AddToBrandAdvertisements(i + 1);
                _advertisements.Add(advert);
            }
        }
    }

    public Task<SaleAdvertisement> GetByIdAsync(int id,
        CancellationToken cancellationToken = default,
        params Expression<Func<SaleAdvertisement, object>>[] includedProperties)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<SaleAdvertisement>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<SaleAdvertisement>> ListAsync(Expression<Func<SaleAdvertisement, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<SaleAdvertisement, object>>[] includedProperties)
    {
        var data = _advertisements.AsQueryable();
        return await Task.Run(()=>data.Where(filter).ToList() as IReadOnlyList<SaleAdvertisement>);
    }

    public Task AddAsync(SaleAdvertisement entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(SaleAdvertisement entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(SaleAdvertisement entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<SaleAdvertisement?> FirstOrDefaultAsync(Expression<Func<SaleAdvertisement, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
