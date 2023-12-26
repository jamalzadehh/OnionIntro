using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionIntro.Application.Abstractions.Repositories;
using OnionIntro.Application.Abstractions.Services;
using OnionIntro.Persistence.Contexts;
using OnionIntro.Persistence.Implementations.Repositories;
using OnionIntro.Persistence.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this  IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
