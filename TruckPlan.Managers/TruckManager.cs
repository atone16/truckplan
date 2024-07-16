using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;
using TruckPlan.Data.Dto;
using TruckPlan.Data.Request;
using TruckPlan.IAccess;
using TruckPlan.IManagers;

namespace TruckPlan.Managers
{
    public class TruckManager : ITruckManager
    {
        private readonly ITruckAccess truckAccess;
        private readonly IMapper mapper;

        public TruckManager(
            ITruckAccess truckAccess,
            IMapper mapper)
        {
            this.truckAccess = truckAccess;
            this.mapper = mapper;
        }

        public async Task<TruckDto> Create(TruckRequest request)
        {
            var truckInput = this.mapper.Map<Truck>(request);
            var truck = await this.truckAccess.CreateAsync(truckInput);
            return this.mapper.Map<TruckDto>(truck);
        }

        public async Task<List<TruckDto>> GetAll()
        {
            var trucks = await this.truckAccess.GetAll();
            return this.mapper.Map<List<TruckDto>>(trucks);
        }

        public async Task<TruckDto> Get(Guid id)
        {
            var truck = await this.truckAccess.GetByIdAsync(id);
            return this.mapper.Map<TruckDto>(truck);
        }

        public async Task<TruckDto> Update(Guid id, TruckRequest request)
        {
            var truckInput = this.mapper.Map<Truck>(request);
            truckInput.Id = id;
            var truck = await this.truckAccess.UpdateAsync(truckInput);
            return this.mapper.Map<TruckDto>(truck);
        }

        public async Task<bool> Unarchive(Guid id)
        {
            var truck = await this.truckAccess.GetByIdAsync(id);
            truck.IsArchived = false;
            await this.truckAccess.UpdateAsync(truck);
            return true;


            throw new NotImplementedException();
        }

        public async Task<bool> Archive(Guid id)
        {
            var truck = await this.truckAccess.GetByIdAsync(id);
            truck.IsArchived = true;
            await this.truckAccess.UpdateAsync(truck);
            return true;
        }
    }
}
