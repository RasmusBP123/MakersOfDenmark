using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IDbContext context;

        public BlogRepository(IDbContext context)
        {
            this.context = context;
        }
        public void Add(Blog blog)
        {
            context.Blog.Add(blog);
        }

        public async Task Delete(Guid id)
        {
            var blog = await GetById(id);
            context.Blog.Remove(blog);
        }

        public async Task<IEnumerable<Blog>> GetAll()
        {
            var blogs = await context.Blog.ToListAsync();
            return blogs;
        }

        public async Task<Blog> GetById(Guid id)
        {
            var blog = await context.Blog.FirstOrDefaultAsync(x => x.Id == id);
            return blog;
        }
    }
}
