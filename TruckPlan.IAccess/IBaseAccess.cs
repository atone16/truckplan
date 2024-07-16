using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;

namespace TruckPlan.IAccess
{
    public interface IBaseAccess<TItem> where TItem : BaseData
    {
        Task<List<TItem>> GetAll();
        Task<TItem> CreateAsync(TItem input);
        Task<TItem> UpdateAsync(TItem item);
        Task<TItem> GetByIdAsync(Guid itemId);
    }
}
