using LibreSDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreSDK.Examples
{
    public class GenerationExample
    {
        public void Generate()
        {
            var hash = "";

            var doc = new Document()
            {
                Encabezado = new Encabezado()
                {
                    IdDoc = new IdDoc
                    {
                        TipoDTE = 33
                    },
                    Emisor = new Emisor()
                    {
                        RUTEmisor = "76015273-0"
                    },
                    Receptor = new Receptor
                    {
                        RUTRecep = "55555555-5",
                        RznSocRecep = "FirstName LastName",
                        GiroRecep = "Particular",
                        DirRecep = "Santiago",
                        CmnaRecep = "Santiago"
                    },

                },
                Detalle = new Detalle
                {
                    NmbItem = "Reservation payment",
                    QtyItem = 1,
                    PrcItem = 150
                },
                Referencia =
                    new Referencia
                    {
                        TpoDocRef = 813,
                        FolioRef = "XXX"
                    }
            };

            LibreSDK.LibreDTE client = new LibreSDK.LibreDTE(hash);
            var tempDocumentResult = client.Post<TempDocumentResponse>("/dte/documentos/emitir", Serialize(doc));

            if (tempDocumentResult.getIsSuccess())
            {
                var tempDocument = tempDocumentResult.getResponse<TempDocumentResponse>();
                var generatorResult = client.Post<DocumentResponse>("/dte/documentos/generar", Serialize(tempDocument));

                if (generatorResult.getIsSuccess())
                {
                    var generarResponse = generatorResult.getResponse<DocumentResponse>();

                    var path = string.Format("/dte/dte_emitidos/pdf/{0}/{1}/{2}", generarResponse.dte, generarResponse.folio, generarResponse.emisor);
                    var pdfResult = client.Get<InvoiceResponse>(path, string.Empty, "application/pdf");
                    
                    var pdfResponse = pdfResult.getResponse<InvoiceResponse>();
                }
                else
                {
                    var message = generatorResult.getMessage();
                    var pdfResponse = new InvoiceResponse
                    {
                        Success = false,
                        Message = message
                    };
                }
            }
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}