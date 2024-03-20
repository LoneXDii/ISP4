using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Persistence.Repository;

internal class FakeCarBrandRepository : IRepository<CarBrand>
{
    List<CarBrand> _carBrands;

    public FakeCarBrandRepository()
    {
        _carBrands = new List<CarBrand>();
        var brand = new CarBrand("Audi", "Best cars");
        brand.Id = 1;
        _carBrands.Add(brand);

        brand = new CarBrand("BMW", "Good car");
        brand.Id = 2;
        _carBrands.Add(brand);
    }

    public Task<CarBrand> GetByIdAsync(int id,
        CancellationToken cancellationToken = default,
        params Expression<Func<CarBrand, object>>[] includedProperties)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<CarBrand>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => _carBrands);
    }

    public Task<IReadOnlyList<CarBrand>> ListAsync(Expression<Func<CarBrand, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<CarBrand, object>>[] includedProperties)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(CarBrand entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CarBrand entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(CarBrand entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CarBrand?> FirstOrDefaultAsync(Expression<Func<CarBrand, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
