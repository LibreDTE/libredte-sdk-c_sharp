using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreSDK.Models
{
    public interface IResponse
    {
    }

    public class RestResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IResponse Response { get; set; }
    }
}
