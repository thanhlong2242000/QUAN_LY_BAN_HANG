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
    public class ListRepository : BaseRepository<BanHangDbContext, List>, IListRepository
    {
        public ListRepository(BanHangDbContext context) : base(context)
        {

        }
    }
}
