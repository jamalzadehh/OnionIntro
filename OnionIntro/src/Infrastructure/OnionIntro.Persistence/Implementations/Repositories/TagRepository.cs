using OnionIntro.Application.Abstractions.Repositories;
using OnionIntro.Domain.Entities;
using OnionIntro.Persistence.Contexts;
using OnionIntro.Persistence.Implementations.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionIntro.Persistence.Implementations.Repositories
{
    public class TagRepository:Repository<Tag>,ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {

        }
    }
}
