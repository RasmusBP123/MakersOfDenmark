using Application.Interfaces;
using Application.ViewModels.Blog;
using AutoMapper;
using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository blogRepository;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public BlogService(IBlogRepository blogRepository,
                               IUnitOfWork uow,
                               IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<bool> Create(CreateBlogViewModel blog)
        {
            var model = Blog.Create(blog.Title, blog.UserId, blog.FirstName,
                blog.LastName, 
                blog.Post, blog.UrlPath);


            blogRepository.Add(model);
            var result = await uow.SaveChangesAsync();

            return result;
        }


        public async Task<IEnumerable<GetListBlogViewModel>> GetAll()
        {
            var blogs = await blogRepository.GetAll();
            var viewModels = mapper.Map<IEnumerable<GetListBlogViewModel>>(blogs);

            return viewModels;
        }

        public async Task<GetSingleBlogViewModel> GetById(Guid id)
        {
            if (id == null || Guid.Empty == id)
                return null;

            var blog = await blogRepository.GetById(id);
            var viewmodel = mapper.Map<GetSingleBlogViewModel>(blog);

            return viewmodel;
        }

        public async Task Delete(Guid id)
        {
            await blogRepository.Delete(id);
            await uow.SaveChangesAsync();
        }
    }
}
