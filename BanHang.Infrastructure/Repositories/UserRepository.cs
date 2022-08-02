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
    public class UserRepository : BaseRepository<BanHangDbContext, User>, IUserRepository
    {
        public UserRepository(BanHangDbContext context) : base(context)
        {

        }

        public object AddUser(User user)
        {
            return null; 
        }

        public object LayThongTin_User()
        {
            return (from a in _context.User
                    select a).ToList();
        }
    }
}
