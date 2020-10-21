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
        Task<IEnumerable<GetListWorkshopViewModel>> GetAllApproved();
        Task<IEnumerable<GetListWorkshopViewModel>> GetAllPending();
        Task<bool> Create(CreateWorkshopViewModel workshop);
        Task<GetSingleWorkshopViewModel> GetById(Guid id);
        Task<GetSingleWorkshopViewModel> ToggleApprovedStateOfWorkshop(Guid id); 
        Task Delete(Guid id);
    }
}
