using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext context;

        public PartService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<PartViewModel>> GetAllAsync()
        {
            var entities = await context.Parts
                .ToListAsync();

            return entities
                .Select(p => new PartViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                    Manufacturer = p.Manufacturer,
                    OriginalMpn = p.OriginalMpn,
                    Description = p.Description,
                    PriceBuy = p.PriceBuy,
                    PriceSell = p.PriceSell
                });
        }
    }
}
