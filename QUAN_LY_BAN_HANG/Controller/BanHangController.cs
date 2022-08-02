using BanHang.Appication.Interfaces;
using BanHang.Appication.Models;
using BanHang.Domain.Models;
using Microsoft.AspNetCore.Mvc;

using System;

namespace QUAN_LY_BAN_HANG.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanHangController : ControllerBase
    {
        private IBanHangServices _BanHangServices;
        public BanHangController(IBanHangServices BanHangServices)
        {
            _BanHangServices = BanHangServices;
        }
    }
}
