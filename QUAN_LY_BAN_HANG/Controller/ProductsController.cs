

using BanHang.Appication.Interfaces;
using BanHang.Appication.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace QUAN_LY_BAN_HANG.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IBanHangServices _BanHangServices;
        public ProductsController(IBanHangServices BanHangServices)
        {
            _BanHangServices = BanHangServices;
        }
        [HttpGet]
        [Route("GetProduct")]
        public ResponseData GetProduct()
        {
            try
            {
                var a = _BanHangServices.GetProduct();
                return new ResponseData(true, "200", a);
            }
            catch(Exception ex)
            {
                return new ResponseData(false, ex.Message, null);
            }
        }
        [HttpGet]
        [Route("GetProduct/{Product_ID}")]
        public ResponseData GetProduct(int Product_ID)
        {
            try
            {
                var a = _BanHangServices.GetProduct(Product_ID);
                return new ResponseData(true, "200", a);
            }
            catch (Exception ex)
            {
                return new ResponseData(false, ex.Message, null);
            }
        }
    }
}
