using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace VTExtensions.P
{

    public class GData {

        /// <summary>
        /// This method get data from input select Form is sended by User.
        /// Only get data from one element select
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="namecombo"></param>
        /// <returns></returns>
        public static string GetComboValueMutiple(HttpRequestBase Request, string namecombo) {
            if (Request[namecombo] != null) {
                return Request[namecombo].ToString();
            }
            return "";
        }


    }
    public class GException {
        public static string GetInnerException(Exception e) {
            var message = e.Message;
            if (e.InnerException == null) {
                return message;
            }
            else {
                return message += GetInnerException(e.InnerException);
            }
        }
        public static string GetDbEntityValidError(DbEntityValidationException dbEx) {
            var msgerror = "";
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    //Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    msgerror += "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;
                }
            }
            return msgerror;
        }
    }
    public class CRMFormatNumber {
        public const string Decimal1P = "{0:0,0}";
    }
    public class CRMString{
        public string GetNumberFString(string decimalstr) {
            return decimalstr.Replace(",", "");
        } 
    }

}
