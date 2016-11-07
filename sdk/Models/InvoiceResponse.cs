using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreSDK.Models
{
    public class InvoiceResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string PdfData { get; set; } 
    }
}
