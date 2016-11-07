namespace LibreSDK.Models
{
    public class TempDocumentResponse : IResponse
    {
        public int emisor { get; set; }
        public int receptor { get; set; }
        public int dte { get; set; }
        public string codigo { get; set; }
    }
}