using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Domain.Entities;

public sealed record Car
{
    public Car(string model, int productionYear)
    {
        Model = model;
        ProductionYear = productionYear;
    }

    private int productionYear; 
    public int ProductionYear
    {
        get 
        {
            return productionYear;

        }

        private set
        {
            if(value < 1970 || value > DateTime.Now.Year)
            {
                throw new ArgumentException("Icorrect production date");
            }
            productionYear = value;
        }
    }

    public string Model { get; private set; }
}
