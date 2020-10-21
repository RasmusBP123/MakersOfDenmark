using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IWorkshopRepository
    {
        void Add(Workshop workshop);
        Task<IEnumerable<Workshop>> GetAllApproved();
        Task<IEnumerable<Workshop>> GetAllPending();
        Task<Workshop> GetById(Guid id);
        Task Delete(Guid id);
    }
}
