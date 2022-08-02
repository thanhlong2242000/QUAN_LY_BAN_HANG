using BanHang.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Appication.Interfaces
{
    public interface IBanHangServices
    {
        object GetProduct();
        object GetUser();
        object GetProduct(int productId);
        object AddUser(User user);
    }
}
