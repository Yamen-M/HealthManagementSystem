using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthManagementSystem
{
    public interface IBill
    {
        string BillID { get; }
        decimal Amount { get; set; }
        string ToString();
    }

    public class Bill: IBill
    {
        public string BillID { get; set; }
        public decimal Amount { get; set; }
        
        
        private readonly IBillingStrategy _billingStrategy;
        public Bill(IBillingStrategy billingStrategy)
        {
            BillID = Guid.NewGuid().ToString();
            
            
            _billingStrategy = billingStrategy;
        }

        public Bill( decimal amount, IBillingStrategy billingStrategy)
        {
            BillID = Guid.NewGuid().ToString();
           _billingStrategy = billingStrategy;
            Amount = _billingStrategy.CalculateBill(amount);
            
        }
        public override string ToString()
        {
            return $"BillID: {BillID}\nAmount t: {Amount:C}";
        }
       
    }

}