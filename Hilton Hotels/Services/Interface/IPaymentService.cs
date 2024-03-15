namespace Hilton_Hotels.Services.Interface
{
    public interface IPaymentService
    {//Ignore
        public double computeCost(DateTime checkin, DateTime checkout);
    }
}
