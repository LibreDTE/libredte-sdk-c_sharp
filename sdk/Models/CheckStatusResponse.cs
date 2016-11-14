using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreSDK.Models
{
    public class CheckStatusResponse : IResponse
    {
        public int track_id { get; set; }
        public string revision_estado { get; set; }
        public string revision_detalle { get; set; }
    }
}
