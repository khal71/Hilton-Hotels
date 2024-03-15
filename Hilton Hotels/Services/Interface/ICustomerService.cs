using Hilton_Hotels.Models;

namespace Hilton_Hotels.Services.Interface
{
    public interface ICustomerService
    {// interface methods for customer
        public void Add(CustomerModel costumer);
        public void Update(CustomerModel costumer);
        public void Delete(string UserName);
        public List<CustomerModel> Get();
        public CustomerModel Find(string UserName);
    }
}
