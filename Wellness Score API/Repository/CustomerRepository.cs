using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Wellness_Score_API.DataContext;
using Wellness_Score_API.Interfaces;
using Wellness_Score_API.Models;

namespace Wellness_Score_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.Where(c => c.CustomerId == id).Include(c => c.Diagnosis).FirstOrDefault();//can also use .AsNoTracking(); for System.InvalidOperationException: The instance of entity type 'Customer' cannot be tracked
            return customer;
        }

        public Customer GetCustomerByName(string name)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Name.Trim().ToUpper() == name.Trim().ToUpper());
            return customer;
        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }
        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.CustomerId == id);
        }
        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.Where(c => c.Email.Trim().ToUpper().Equals(email.Trim().ToUpper())).FirstOrDefault();

        }
        public int GetWellnessScore(Customer customer)
        {
            int count = 0;
            if (customer.Age > 35 && customer.Diagnosis.HBA1C_FBS > 6.0 && customer.Diagnosis.Pulse > 75 && customer.Diagnosis.HBP > 130)
            {
                count++;
            }
            if (customer.Age > 30 && customer.Diagnosis.BMI > 30)
            {
                count++;
            }
            if (customer.Diagnosis.Creatinine > 0.6 && customer.Diagnosis.Creatinine < 1.3)
            {
                count++;
            }
            if (customer.Diagnosis.Cholesterol > 120 && customer.Diagnosis.Cholesterol < 200)
            {
                count++;
            }
            if (count == 0)
                return 10;
            else if (count == 1)
                return 7;
            else if (count == 2)
                return 5;
            else if (count == 3)
                return 4;
            else if (count == 4)
                return 2;
            return 1;



        }

    }
}
