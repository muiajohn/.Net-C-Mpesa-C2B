using System;
using System.Web.Services;

namespace MpesaService
{
    /// <summary>
    /// Confirm and validate Mpesa Payments
    /// </summary>
    [WebService(Namespace = "http://yourdomain.com/",
        Description= "Confirm and validate Mpesa Payments", Name = "C2BPaymentConfirmationRequest")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ConfimationAndValidation : WebService,IMpesaOperations
    {
       
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
        [WebMethod(MessageName = "C2BPaymentConfirmationRequest")]
        public string C2BPaymentConfirmationRequest(string TransType, string TransID, 
            string TransTime, string TransAmount, string BusinessShortCode, string BillRefNumber, 
            string InvoiceNumber, string OrgAccountBalance, string ThirdPartyTransID,
            string MSISDN, KYCInfo KYCInfo, KYCInfo KYCinfo)
        {
            //save to your db and return success
            return "Success?";
        }

        [WebMethod(MessageName = "C2BPaymentValidationRequest")]
        public C2BPaymentValidationResult C2BPaymentValidationRequest(string TransType, string TransID,
            string TransTime, string TransAmount, string BusinessShortCode, string BillRefNumber,
            string InvoiceNumber, string MSISDN, KYCInfo KYCInfo, KYCInfo KYCinfo)
        {
            var dx = "";//dx is just a var showing you how to verify, perhaps pull row from your db using TransID 
            if (dx != null)
            {
                return new C2BPaymentValidationResult
                {
                    ResultCode = "0",
                    ResultDesc = "Service processing successful",
                    //ThirdPartyTransID = dx.ThirdPartyTransID
                };
            }
            else
            {
                return new C2BPaymentValidationResult
                {
                    ResultCode = "1",
                    ResultDesc = "Service processing unsuccessful",
                    ThirdPartyTransID = ""
                };
            }
        }
    }
}
