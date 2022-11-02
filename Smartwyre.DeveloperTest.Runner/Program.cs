using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var paymentService = new PaymentService(new AccountDataStore());
            var result = paymentService.MakePayment(new MakePaymentRequest() { Amount = 123, DebtorAccountNumber = 1, PaymentScheme = PaymentScheme.BankToBankTransfer });

            Console.WriteLine($"Payment Result: {result.Success}");
        }
    }
}
