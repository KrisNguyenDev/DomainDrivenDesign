﻿using CleanArchWithCQRSandMediator.Domain.Repository;
using CleanArchWithCQRSandMediator.Infra.Data;
using CleanArchWithCQRSandMediator.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BlogDbContext") ?? throw new InvalidOperationException("connection string 'BlogDbContext not found'."));
            });

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
