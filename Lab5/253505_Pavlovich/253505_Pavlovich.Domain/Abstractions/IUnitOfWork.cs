using _253505_Pavlovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Domain.Abstractions;

public interface IUnitOfWork
{
    IRepository<CarBrand> CarBrandRepository { get; }
    IRepository<SaleAdvertisement> SaleAdvertisementRepository { get; }
    public Task SaveAllAsync();
    public Task DeleteDatabaseAsync();
    public Task CreateDatabaseAsync();
}
