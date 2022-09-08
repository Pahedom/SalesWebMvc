using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var salesRecords = _context.SalesRecord.Select(obj => obj);

            if (minDate.HasValue)
            {
                salesRecords = salesRecords.Where(obj => obj.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                salesRecords = salesRecords.Where(obj => obj.Date <= maxDate.Value);
            }

            return await salesRecords.Include(obj => obj.Seller).Include(obj => obj.Seller.Department).OrderByDescending(obj => obj.Date).ToListAsync();
        }
    }
}