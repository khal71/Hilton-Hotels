using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using System.Text.Json;

namespace Hilton_Hotels.Services
{
    public class CustomerServiceJson : ICustomerService
    {
        //customer Methods (Khaled)

       private const string fileDir = "../Hilton Hotels/wwwroot/Jsonfiles/";
        private const string fileName = fileDir + "CustomerJson.json";

        List<CustomerModel> _customers = new List<CustomerModel>();
        public CustomerServiceJson()
        {
            _customers = ReadFromJson();
        }

        public void Add(CustomerModel costumer)
        {
            // we check if there exists a customer with that user name and if not add the customer and saves in json files
            var result = Find(costumer.Username);
            if (result is not null )
            {
                throw new Exception("UserName exists"); 
            }
            _customers.Add(costumer);
            SaveToJson();
        }
        // we use the find method to find the customer by their username and removes them
        public void Delete(string UserName)
        {
            CustomerModel customer = Find(UserName);
            _customers.Remove(customer);
            SaveToJson();
            
        }
        //Looks and shows the files from json
        public List<CustomerModel> ReadFromJson()
        {
            using(var file = File.OpenText(fileName))
            {
                
                String json= file.ReadToEnd();
                return JsonSerializer.Deserialize<List<CustomerModel>>(json);
            }
            return new List<CustomerModel>();
        }
        //we use this method to find the customer with a username
        public CustomerModel Find(string UserName)
        {
            CustomerModel c = _customers.Find(c => c.Username == UserName);
            if (c is not null)
            {
                return c;
            }
            return null;
            
        }
        // we use the find method to find the customer with the username and update their info and save it to json
        public void Update(CustomerModel newCustomer)
        {
            CustomerModel customer = Find(newCustomer.Username);

            customer.Name = newCustomer.Name;
            customer.Username = newCustomer.Username;
            customer.Password = newCustomer.Password;

            SaveToJson();
        }

        // this method saves text to json
        private void SaveToJson()
        {
            String json = JsonSerializer.Serialize(_customers);
            File.WriteAllText(fileName, json);
        }
        // with this method we get a list of the customers
        public List<CustomerModel> Get()
        {
            return new List<CustomerModel>(_customers);
        }
    }
}
