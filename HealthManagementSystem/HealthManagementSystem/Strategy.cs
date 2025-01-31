using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthManagementSystem
{
    public interface IBillingStrategy
    {
        decimal CalculateBill(decimal amount);
    }

    public class NormalBillingStrategy : IBillingStrategy
    {
        public decimal CalculateBill(decimal amount)
        {
            return amount;
        }
    }

    public class DiscountBillingStrategy : IBillingStrategy
    {
        public decimal CalculateBill(decimal amount)
        {
            return amount* 0.9M;
        }
    }

}
