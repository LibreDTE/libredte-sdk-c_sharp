using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreSDK.Models
{
    public class DocumentResponse : IResponse
    {
        public int emisor { get; set; }
        public int dte { get; set; }
        public int folio { get; set; }
        public bool certificacion { get; set; }
        public int tasa { get; set; }
        public DateTime fecha { get; set; }
        public int sucursal_sii { get; set; }
        public int receptor { get; set; }
        public string exento { get; set; }
        public string neto { get; set; }
        public string iva { get; set; }
        public string total { get; set; }
        public string usario { get; set; }
        public string track_id { get; set; }
        public string xml {get;set;}
        public string revision_estado { get; set; }
        public string revision_detalle { get; set; }
    }
}
