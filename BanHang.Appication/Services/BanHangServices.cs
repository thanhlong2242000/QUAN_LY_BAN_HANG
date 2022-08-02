using BanHang.Appication.Interfaces;
using BanHang.Domain.Interfaces;
using BanHang.Domain.Models;


namespace BanHang.Appication.Services
{
    public class BanHangServices : IBanHangServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;


        public BanHangServices(
            IProductRepository productRepository,
            IUserRepository userRepository
            )
        {

            _productRepository = productRepository;
            _userRepository = userRepository;

        }

        public object GetProduct()
        {
            var ds = _productRepository.GetProduct();
            return ds;
        }
        public object GetUser()
        {
            var ds = _userRepository.LayThongTin_User();
            return ds;
        }
        public object GetProduct(int Product_ID)
        {
            return null;
        }

        public object AddUser(User user)
        {
            var a = _userRepository.AddUser(user);
            return a;
        }
    }
}
