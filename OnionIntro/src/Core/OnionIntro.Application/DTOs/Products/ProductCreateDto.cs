using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.DTOs.Products
{
    public record ProductCreateDto(string Name,decimal Price,string SKU,string? Description,int CategoryId,ICollection<int> ColorIds,ICollection<int> TagIds);
    
    
}
