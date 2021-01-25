using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Data;
using SaleWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SaleWebMVCContext _context;

        public SalesRecordService(SaleWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Sales select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);

            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
