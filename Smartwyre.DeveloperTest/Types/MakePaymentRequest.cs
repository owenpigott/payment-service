using System;

namespace Smartwyre.DeveloperTest.Types
{
    public class MakePaymentRequest
    {
        public int CreditorAccountNumber { get; set; }

        public int DebtorAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentScheme PaymentScheme { get; set; }
    }
}
