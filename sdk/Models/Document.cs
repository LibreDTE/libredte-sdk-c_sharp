using System;
using System.Collections.Generic;

namespace LibreSDK.Models
{
    public class Encabezado
    {
        public IdDoc IdDoc { get; set; }
        public Emisor Emisor { get; set; }
        public string RUTMandante { get; set; }
        public Receptor Receptor { get; set; }
        public string RUTSolicita { get; set; }
        //public Transporte Transporte {get;set;}
        public Totales Totales { get; set; }
        //public OtraMoneda OtraMoneda { get; set; }
    }

    public class IdDoc
    {
        public int TipoDTE { get; set; }
        public int? Folio { get; set; }
        public DateTime? FchEmis {get;set;}
        public int? IndNoRebaja { get; set; }
        public int? TipoDespacho { get; set; }
        public int? IndTraslado { get; set; }
        public string TpoImpresion { get; set; }
        public int? IndServicio { get; set; }
        public int? MntBruto { get; set; }
        public int? FmaPago { get; set; }
        public int? FmaPagExp { get; set; }
        public DateTime? FchCancel { get; set; }
        public decimal? MntCancel { get; set; }
        public decimal? SaldoInsol { get; set; }
        public DateTime? PeriodoDesde { get; set; }
        public DateTime? PeriodoHasta { get; set; }
        public string MedioPago { get; set; }
        public string TpoCtaPago { get; set; }
        public string NumCtaPago { get; set; }
        public string BcoPago { get; set; }
        public string TermPagoCdg { get; set; }
        public string TermPagoGlosa { get; set; }
        public int? TermPagoDias { get; set; }
        public DateTime? FchVenc { get; set; }
    }

    public class Emisor
    {
        public string RUTEmisor { get; set; }
        public string RznSoc { get; set; }
        public string GiroEmis { get; set; }
        public string Telefono { get; set; }
        public string CorreoEmisor { get; set; }
        public int Acteco { get; set; }
        //public string GuiaExport { get; set; }
        public string Sucursal { get; set; }
        public int CdgSIISucur { get; set; }
        public string DirOrigen { get; set; }
        public string CmnaOrigen { get; set; }
        public string CiudadOrigen { get; set; }
        public string CdgVendedor { get; set; }
        public string IdAdicEmisor { get; set; }
    }

    public class Extranjero
    {
        public string NumId { get; set; }
        public int Nacionalidad { get; set; }
    }

    public class Receptor
    {
        public string RUTRecep { get; set; }
        public string CdgIntRecep { get; set; }
        public string RznSocRecep { get; set; }
        public Extranjero Extranjero { get; set; }
        public string GiroRecep { get; set; }
        public string Contacto { get; set; }
        public string CorreoRecep { get; set; }
        public string DirRecep { get; set; }
        public string CmnaRecep { get; set; }
        public string CiudadRecep { get; set; }
        public string DirPostal { get; set; }
        public string CmnaPostal { get; set; }
        public string CiudadPostal { get; set; }
    }

    public class Totales
    {
        public string TpoMoneda { get; set; }

        public string MntNeto { get; set; }
        public string MntExe { get; set; }
        public string MntBase { get; set; }
        public string MntMargenCom { get; set; }
        public decimal? TasaIVA { get; set; }
        public string IVA { get; set; }
        public string IVAProp { get; set; }
        public string IVATerc { get; set; }
        //public string TpoMoneda { get; set; }
    }

    public class Detalle
    {
        public int? IndExe { get; set; }
        public string NmbItem { get; set; }
        public int? QtyItem { get; set; }
        public decimal PrcItem { get; set; }
    }

    public class Referencia
    {
        public int? TpoDocRef { get; set; }
        public object FolioRef { get; set; }
        public string FchRef { get; set; }
        public int? CodRef { get; set; }
        public string RazonRef { get; set; }
    }

    public class Document
    {
        public Encabezado Encabezado { get; set; }
        public Detalle Detalle { get; set; }
        public List<Referencia> Referencia { get; set; }
    }
}
