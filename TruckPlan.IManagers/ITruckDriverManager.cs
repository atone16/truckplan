using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;
using TruckPlan.Data.Dto;
using TruckPlan.Data.Request;

namespace TruckPlan.IManagers
{
    public interface ITruckDriverManager
    {
        Task<List<TruckDriverDto>> GetAll();
        Task<TruckDriverDto> Get(Guid id);
        Task<TruckDriverDto> Create(TruckDriverRequest request);
        Task<TruckDriverDto> Update(Guid id, TruckDriverRequest request);
        Task<bool> Archive(Guid id);
        Task<bool> Unarchive(Guid id);
    }
}
