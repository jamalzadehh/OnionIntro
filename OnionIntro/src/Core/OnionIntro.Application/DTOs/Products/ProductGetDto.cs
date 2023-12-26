using OnionIntro.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Application.DTOs.Products
{
    public  record ProductGetDto(int Id,string Name, decimal Price, string SKU,string? Description,int CategoryId,IncludeCategoryDto Category);        
}
