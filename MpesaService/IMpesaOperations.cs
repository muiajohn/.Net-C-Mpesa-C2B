namespace MpesaService
{
    public interface IMpesaOperations
    {
        string C2BPaymentConfirmationRequest(string TransType, 
            string TransID, string TransTime, string TransAmount, 
            string BusinessShortCode, string BillRefNumber,string InvoiceNumber, 
            string OrgAccountBalance,string ThirdPartyTransID, string MSISDN,
            KYCInfo KYCInfo, KYCInfo KYCinfo);
        C2BPaymentValidationResult C2BPaymentValidationRequest(string TransType,
            string TransID, string TransTime, string TransAmount, 
            string BusinessShortCode, string BillRefNumber, string InvoiceNumber, 
            string MSISDN, KYCInfo KYCInfo, KYCInfo KYCinfo);
    }
}