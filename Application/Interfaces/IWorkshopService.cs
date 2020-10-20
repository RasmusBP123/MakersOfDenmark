using Application.ViewModels;
using Application.ViewModels.Workshop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWorkshopService
    {
        Task<bool> Create(CreateWorkshopViewModel workshop);
        Task<IEnumerable<GetListWorkshopViewModel>> GetAll();
        Task<GetSingleWorkshopViewModel> GetById(Guid id);
        Task Delete(Guid id);
    }
}
