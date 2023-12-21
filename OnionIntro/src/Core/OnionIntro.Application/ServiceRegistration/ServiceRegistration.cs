using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OnionIntro.Application.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
       public static IServiceCollection AddAplicationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            //service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddFluentValidation();
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return service;
        }                
    }
}
