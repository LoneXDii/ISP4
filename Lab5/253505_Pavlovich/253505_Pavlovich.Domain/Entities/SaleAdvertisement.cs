using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Domain.Entities;

public class SaleAdvertisement : Entity
{
    public SaleAdvertisement(string name, Car carInfo, Salesman salesmanInfo, double cost)
    {
        if (carInfo.ProductionYear < 1980
            || carInfo.ProductionYear > DateTime.Now.Year)
        {
            throw new ArgumentException("Incorrect production date");
        }
        Name = name;
        CarInfo = carInfo;
        SalesmanInfo = salesmanInfo;
        Cost = cost;
    }

    public string Name { get; set; }
    public Car CarInfo { get; private set; }
    public Salesman SalesmanInfo { get; private set; }
    public double Cost { get; private set; }
    public int CarModelId { get; private set; }

    public void AddToBrandAdvertisements(int carModeId)
    {
        if (CarModelId <= 0) return;
        CarModelId = CarModelId;
    }

    public void DeleteFromBrandAdvertisements()
    {
        CarModelId = 0;
    }

    public void ChangeCost(double cost)
    {
        Cost = cost;
    }
}
