using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Validators
{
    // Crude example - I was refactoring validation out. Would consider Fluent Validation depending on situation.

    public interface IPaymentValidator
    {
        bool Validate(Account account, MakePaymentRequest request);
    }

    public class ExpediatedPaymentValidator : IPaymentValidator
    {
        public bool Validate(Account account, MakePaymentRequest request)
        {
            return account.Balance > request.Amount;
        }
    }

    public class AutomatedPaymentValidator : IPaymentValidator
    {
        public bool Validate(Account account, MakePaymentRequest request)
        {
            return account.Status == AccountStatus.Live;
        }
    }

    public class BankToBankPaymentValidator : IPaymentValidator
    {
        public bool Validate(Account account, MakePaymentRequest request)
        {
            return true;
        }
    }

    // TODO: This would be injected etc. Biggest question - How do we genericise without requiring too much boilerplate?
    // New classes for new payment types may be more SOLID but still a lot of work.
    public static class ValidatorGetter
    {
      public static  Dictionary<PaymentScheme, IPaymentValidator> Validators = new Dictionary<PaymentScheme, IPaymentValidator>
      {
         { PaymentScheme.AutomatedPaymentSystem, new AutomatedPaymentValidator() },
         { PaymentScheme.ExpeditedPayments, new ExpediatedPaymentValidator() },
         { PaymentScheme.BankToBankTransfer, new BankToBankPaymentValidator() }
      };
    } 
}
