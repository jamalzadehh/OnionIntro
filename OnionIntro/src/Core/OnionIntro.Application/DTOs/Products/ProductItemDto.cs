using OnionIntro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.DTOs.Products
{
    public record ProductItemDto(int Id,string Name,decimal Price,string SKU,string? Description);
    
}
