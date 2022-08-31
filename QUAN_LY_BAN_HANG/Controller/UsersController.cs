using BanHang.Appication.Interfaces;
using BanHang.Appication.Models;
using BanHang.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace QUAN_LY_BAN_HANG.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBanHangServices _BanHangServices;
        public UsersController(IBanHangServices BanHangServices)
        {
            _BanHangServices = BanHangServices;
        }
        [HttpGet]
        [Route("GetUser")]
        public ResponseData GetUser()
        {
            try
            {
                var ab = _BanHangServices.GetUser();
                return new ResponseData(true, "200", ab);
            }
            catch (Exception ex)
            {
                return new ResponseData(false, ex.Message, null);
            }
        }
        [HttpPost]
        [Route("AddUser")]
        public ResponseData AddUser(User user)
        {
            try
            {
                var themmoiuser = _BanHangServices.AddUser(user);

                return new ResponseData(true, "200", themmoiuser);
            }
            catch (Exception ex)
            {
                return new ResponseData(false, ex.Message, null);
            }
        }
    }
}
