using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data.Dto;
using TruckPlan.Data.Request;

namespace TruckPlan.IManagers
{
    public interface ITruckManager
    {
        Task<List<TruckDto>> GetAll();
        Task<TruckDto> Get(Guid id);
        Task<TruckDto> Create(TruckRequest request);
        Task<TruckDto> Update(Guid id, TruckRequest request);
        Task<bool> Archive(Guid id);
        Task<bool> Unarchive(Guid id);
    }
}
