﻿using _253505_Pavlovich.Persistence.Data;
using _253505_Pavlovich.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, 
                                        DbContextOptions options)
    {
        services.AddPersistence().AddSingleton<AppDbContext>(
               new AppDbContext((DbContextOptions<AppDbContext>)options));

        return services;
    }
}
