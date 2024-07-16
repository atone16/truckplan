using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;
using TruckPlan.EntityFramework;
using TruckPlan.IAccess;

namespace TruckPlan.Access
{
    public class BaseAccess<TItem> : IBaseAccess<TItem> where TItem : BaseData
    {
        private readonly ApplicationDBContext applicationDBContext;
        private readonly DbSet<TItem> dbSet;

        public BaseAccess(ApplicationDBContext applicationDBContext) 
        { 
            this.applicationDBContext = applicationDBContext;
            this.dbSet = applicationDBContext.Set<TItem>();
        }

        public async Task<TItem> CreateAsync(TItem input)
        {
            if (input == null) throw new ArgumentNullException(nameof(TItem));

            try
            {
                input.DateCreated = DateTime.Now;
                await this.dbSet.AddAsync(input);
                await this.applicationDBContext.SaveChangesAsync();
                return input;
            }
            catch(Exception ex)
            {
                throw new Exception($"Create failed for entity ${nameof(TItem)}");
            }
        }

        public async Task<TItem> GetByIdAsync(Guid itemId)
        {
            if (itemId == Guid.Empty)
                throw new ArgumentException("Cannot have an Empty Guid");

            return await this.dbSet.FindAsync(itemId);
        }

        /// <summary>
        /// Dont Use all the time, only use on limited circumstances
        /// </summary>
        /// <returns></returns>
        public async Task<List<TItem>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<TItem> UpdateAsync(TItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            try
            {
                var actualItem = await this.dbSet.FindAsync(item.Id);

                if (actualItem == null || actualItem.IsArchived)
                    throw new Exception("Cant update a nonexistent or archived item");

                this.dbSet.Attach(item);
                applicationDBContext.Entry(item).State = EntityState.Modified;
                await this.applicationDBContext.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed for entity ${nameof(TItem)}");            
            }
        }
    }
}
