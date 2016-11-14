using LibreSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreSDK.Examples
{
    public class CheckStatusExample
    {
        public void CheckStatus()
        {
            var hash = "";
            var dte = 110;
            var folio = 89;
            var rut = "76015273";
            var metodo = 1;

            LibreSDK.LibreDTE client = new LibreSDK.LibreDTE(hash);

            var path = string.Format("/dte/dte_emitidos/actualizar_estado/{0}/{1}/{2}?usarWebservice={3}", dte, folio, rut, metodo);
            var checkResult = client.Get<CheckStatusResponse>(path, string.Empty);

           if(checkResult.getIsSuccess())
           {
               var response = checkResult.getResponse<CheckStatusResponse>();
           }
           else
           {
               var statusCode = checkResult.getStatus();
           }
        }
    }
}