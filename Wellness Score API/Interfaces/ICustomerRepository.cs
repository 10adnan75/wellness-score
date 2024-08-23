using Wellness_Score_API.Models;

namespace Wellness_Score_API.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByName(string name);
        Customer GetCustomerByEmail(string email);
        int GetWellnessScore(Customer customer);
        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        bool CustomerExists(int id);
        bool Save();
    }
}
