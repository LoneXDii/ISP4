using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1Pavlovich253505.Entities;

namespace Lab1Pavlovich253505.Services;

public interface IRateService
{
    IEnumerable<Rate> GetRates(DateTime date);
}
