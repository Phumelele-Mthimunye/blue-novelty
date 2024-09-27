using Domain.Data;
using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Entities;
using Domain.Models.Interfaces.Adapters;
using Microsoft.EntityFrameworkCore;
using SharedServices;
using System.Collections.Generic;
using System.Linq;

namespace AdminService.Adapters
{
    public class HouseholdDetailAdapter : IHouseholdDetailAdapter
    {
        private readonly AppDbContext _context;

        public HouseholdDetailAdapter(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(DeleteDBRequest request)
        {
            var entity = _context.HouseholdDetails.FirstOrDefault(x => x.Id == request.Id);
            if (entity != null)
            {
                entity.Active = false;
                _context.SaveChanges();
            }
        }

        public HouseholdDetailDetailDTO Insert(HouseholdDetailDTO request)
        {
            var entity = new HouseholdDetail(request);
            _context.HouseholdDetails.Add(entity);
            _context.SaveChanges();
            return _context.HouseholdDetails
                .Where(x => x.Id == entity.Id)
                .Select(x => x.ToDto())
                .FirstOrDefault();
        }

        public List<HouseholdDetailDetailDTO> Read(HouseholdDetailDetailDTO request)
        {
            return _context.HouseholdDetails
                .Where(x => x.Id == request.Id)
                .Select(x => x.ToDto())
                .ToList();
        }

        public HouseholdDetailDetailDTO Update(HouseholdDetailWithIdDTO request)
        {
            var entity = _context.HouseholdDetails.FirstOrDefault(x => x.Id == request.Id);
            if (entity != null)
            {
                entity.MapUpdateValues(request);
                _context.SaveChanges();
            }
            return _context.HouseholdDetails
                .Where(x => x.Id == request.Id)
                .Select(x => x.ToDto())
                .FirstOrDefault();
        }
    }
}
