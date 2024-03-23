using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Domain.Entities;

public class SaleAdvertisement : Entity
{
    private SaleAdvertisement() { }
    public SaleAdvertisement(string name, Car carInfo, Salesman salesmanInfo, double price)
    {
        if (carInfo.ProductionYear < 1980
            || carInfo.ProductionYear > DateTime.Now.Year)
        {
            throw new ArgumentException("Incorrect production date");
        }
        Name = name;
        CarInfo = carInfo;
        SalesmanInfo = salesmanInfo;
        Price = price;
    }

    public string Name { get; set; }
    public Car CarInfo { get; private set; }
    public Salesman SalesmanInfo { get; private set; }
    public double Price { get; private set; }
    public int? CarBrandId { get; private set; }

    public void AddToBrandAdvertisements(int carBrandId)
    {
        if (carBrandId <= 0) return;
        CarBrandId = carBrandId;
    }

    public void DeleteFromBrandAdvertisements()
    {
        CarBrandId = 0;
    }

    public void ChangePrice(double price)
    {
        Price = price;
    }
}
