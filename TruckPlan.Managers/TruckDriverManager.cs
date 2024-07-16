using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TruckPlan.Data;
using TruckPlan.Data.Dto;
using TruckPlan.Data.Request;
using TruckPlan.IAccess;
using TruckPlan.IManagers;

namespace TruckPlan.Managers
{
    public class TruckDriverManager : ITruckDriverManager
    {
        private readonly ITruckDriverAccess truckDriverAccess;
        private readonly IMapper mapper;

        public TruckDriverManager(ITruckDriverAccess truckDriverAccess, IMapper mapper) 
        {
            this.truckDriverAccess = truckDriverAccess;
            this.mapper = mapper;
        }

        public async Task<TruckDriverDto> Create(TruckDriverRequest createTruckDriverRequest)
        {
            var truckDriverInput = this.mapper.Map<TruckDriver>(createTruckDriverRequest);
            var truckDriver = await this.truckDriverAccess.CreateAsync(truckDriverInput);
            return this.mapper.Map<TruckDriverDto>(truckDriver);
        }

        public async Task<TruckDriverDto> Get(Guid id)
        {
            var truckDriver = await this.truckDriverAccess.GetByIdAsync(id);
            return this.mapper.Map<TruckDriverDto>(truckDriver);
        }

        public async Task<List<TruckDriverDto>> GetAll()
        {
            var truckDrivers = await this.truckDriverAccess.GetAll();
            return this.mapper.Map<List<TruckDriverDto>>(truckDrivers);
        }

        public async Task<TruckDriverDto> Update(Guid id, TruckDriverRequest updateTruckDriverRequest)
        {
            var truckDriverInput = this.mapper.Map<TruckDriver>(updateTruckDriverRequest);
            truckDriverInput.Id = id;
            var truckDriver = await this.truckDriverAccess.UpdateAsync(truckDriverInput);
            return this.mapper.Map<TruckDriverDto>(truckDriver);
        }

        public async Task<bool> Archive(Guid id)
        {
            var truckDriver = await this.truckDriverAccess.GetByIdAsync(id);
            truckDriver.IsArchived = true;
            await this.truckDriverAccess.UpdateAsync(truckDriver);
            return true;
        }

        public async Task<bool> Unarchive(Guid id)
        {
            var truckDriver = await this.truckDriverAccess.GetByIdAsync(id);
            truckDriver.IsArchived = false;
            await this.truckDriverAccess.UpdateAsync(truckDriver);
            return true;
        }
    }
}
