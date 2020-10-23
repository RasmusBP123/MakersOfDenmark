using Application.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBlogService
    {
        Task<bool> Create(CreateBlogViewModel blog);
        Task<IEnumerable<GetListBlogViewModel>> GetAll();
        Task<GetSingleBlogViewModel> GetById(Guid id);
        Task Delete(Guid id);
    }
}
