using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Appication.Models
{
    public class ResponseData
    {
        public bool State { get; set; }
        public string Massage { get; set; }
        public object Data { get; set; }

        public ResponseData(bool state , string msg , object Data)
        {
            this.Data = Data;
            this.State = state;
            this.Massage = msg;
        }
    }
}
