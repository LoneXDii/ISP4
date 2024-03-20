using _253505_Pavlovich.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Persistence.Repository;

internal class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Lazy<IRepository<CarBrand>> _brandRepository;
    private readonly Lazy<IRepository<SaleAdvertisement>> _advertisementRepository;

    public EfUnitOfWork(AppDbContext context)
    {
        _context = context;
        _brandRepository = new Lazy<IRepository<CarBrand>>(() => new EfRepository<CarBrand>(context));
        _advertisementRepository = new Lazy<IRepository<SaleAdvertisement>>(() =>
                                                        new EfRepository<SaleAdvertisement>(context));
    }

    public IRepository<CarBrand> CarBrandRepository => _brandRepository.Value;
    public IRepository<SaleAdvertisement> SaleAdvertisementRepository => _advertisementRepository.Value;

    public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
    public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();
    public async Task SaveAllAsync() => await _context.SaveChangesAsync();
}
