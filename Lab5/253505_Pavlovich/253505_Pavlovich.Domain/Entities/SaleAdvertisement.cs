﻿using System;
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
        Name = name;
        CarInfo = carInfo;
        SalesmanInfo = salesmanInfo;
        Price = price;
    }

    public string Name { get; set; }
    public Car CarInfo { get; set; }
    public Salesman SalesmanInfo { get; set; }
    public double Price { get; set; }
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
