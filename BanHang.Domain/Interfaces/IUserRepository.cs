using BanHang.Domain.Models;
using BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        object LayThongTin_User();
        object AddUser(User user);
    }
}
