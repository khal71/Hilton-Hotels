using Hilton_Hotels.Services.Interface;
using Microsoft.VisualBasic;

namespace Hilton_Hotels.Services
{
    public class PaymentService : IPaymentService
    {//Ignore
        public double computeCost(DateTime checkin, DateTime checkout)
        {
            double pay = 0;

            
           
            
                var days = (checkout - checkin).TotalDays;
            
            if (days <= 5)
            {
                pay = 20;
                return pay;
            }
            else
            {

                pay = 20;
                double newday = days - 5;
                newday *= 10;
                pay += newday;
                return pay;
            }
            
        }
    }
}
