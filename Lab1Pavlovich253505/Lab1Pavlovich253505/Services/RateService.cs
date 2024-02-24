using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab1Pavlovich253505.Entities;

namespace Lab1Pavlovich253505.Services;

internal class RateService : IRateService
{
    private HttpClient httpClient;

    public RateService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public IEnumerable<Rate> GetRates(DateTime date)
    {
        IEnumerable<Rate>? rates;
        string request = $"?ondate={date.ToString("yyyy-MM-dd")}&periodicity=0";
        rates = Task.Run(async () => await httpClient.GetFromJsonAsync<List<Rate>>(request)).Result;
        return rates;
    }
}
