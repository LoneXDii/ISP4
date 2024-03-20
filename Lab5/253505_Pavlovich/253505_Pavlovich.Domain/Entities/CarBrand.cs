using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Domain.Entities;

public class CarBrand : Entity
{
    private List<SaleAdvertisement> _advertisements = new();

    public CarBrand(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<SaleAdvertisement> Advertisements { get => _advertisements.AsReadOnly(); }
}
