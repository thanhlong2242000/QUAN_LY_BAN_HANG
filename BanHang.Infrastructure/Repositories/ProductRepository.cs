using BanHang.Domain.Interfaces;
using BanHang.Domain.Models;
using BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<BanHangDbContext, Product>, IProductRepository
    {
        public ProductRepository(BanHangDbContext context) : base(context)
        {
        }
        public object GetProduct()
        {
            return (from a in _context.Product
                    select a).ToList();
        }
    }
}
