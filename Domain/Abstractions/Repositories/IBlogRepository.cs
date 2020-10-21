using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IBlogRepository
    {
        void Add(Blog blog);
        Task<IEnumerable<Blog>> GetAll();
        Task<Blog> GetById(Guid id);
        Task Delete(Guid id);
        Task Upload();
    }
}
