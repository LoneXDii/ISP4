using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Application;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();

        await unitOfWork.DeleteDataBaseAsync();
        await unitOfWork.CreateDataBaseAsync();

        var brands = new List<CarBrand>();
        brands.Add(new CarBrand("Audi", "Best car"));
        brands.Add(new CarBrand("BMW", "Good car"));
        foreach (var brand in brands)
        {
            await unitOfWork.CarBrandRepository.AddAsync(brand);
        }
        await unitOfWork.SaveAllAsync();

        var advert = new SaleAdvertisement("Selling a 2022 Audi RS7",
                        new Car("RS7", 2022),
                        new Salesman("Walter", "+375-29-111-11-11"),
                        160000);
        advert.AddToBrandAdvertisements(1);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 2012 Audi A6",
                       new Car("A6 C7", 2012),
                       new Salesman("Vasya", "+375-29-123-32-23"),
                       20000);
        advert.AddToBrandAdvertisements(1);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 1993 Audi 80",
                       new Car("80 B4", 1993),
                       new Salesman("Vitya", "+375-44-987-65-43"),
                       4500);
        advert.AddToBrandAdvertisements(1);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 2021 Audi RS e-tron GT",
                       new Car("RS e-tron GT", 2021),
                       new Salesman("Petya", "+375-29-324-21-64"),
                       110000);
        advert.AddToBrandAdvertisements(1);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 2012 Audi A6",
                       new Car("A6", 2012),
                       new Salesman("Vasya", "+375-29-123-32-23"),
                       20000);
        advert.AddToBrandAdvertisements(1);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 2021 Audi Q7",
                       new Car("Q7 4M", 2021),
                       new Salesman("Vova", "+375-44-254-23-74"),
                       64000);
        advert.AddToBrandAdvertisements(1);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);


        advert = new SaleAdvertisement("Selling a 2023 BMW M5",
                       new Car("M5 F90", 2023),
                       new Salesman("Denis", "+375-29-951-14-12"),
                       130000);
        advert.AddToBrandAdvertisements(2);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 2019 BMW X5",
                       new Car("X5 G05", 2019),
                       new Salesman("Walter", "+375-29-111-11-11"),
                       60000);
        advert.AddToBrandAdvertisements(2);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 2019 BMW X5",
                       new Car("X5 G05", 2019),
                       new Salesman("Walter", "+375-29-111-11-11"),
                       60000);
        advert.AddToBrandAdvertisements(2);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        advert = new SaleAdvertisement("Selling a 2017 BMW I8",
                       new Car("I8 I", 2017),
                       new Salesman("Anton", "+375-44-245-23-56"),
                       75000);
        advert.AddToBrandAdvertisements(2);
        await unitOfWork.SaleAdvertisementRepository.AddAsync(advert);

        await unitOfWork.SaveAllAsync();
    }
}
