using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Validators;
using System;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore _accountDataStore;

        public PaymentService(IAccountDataStore accountDataStore)
        {
            _accountDataStore = accountDataStore ?? throw new ArgumentNullException(nameof(accountDataStore));
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            Account account = _accountDataStore.GetAccount(request.DebtorAccountNumber) 
                ?? throw new Exception($"Requested account not found. Account Number for context. (Sorry GDPR): {request.DebtorAccountNumber}");

            // TODO: Lots on validation. The structure as a whole needs work to avoid account/request being passed around
            // and pushing correct responsibility to appropriate classes.
            var validator = ValidatorGetter.Validators[request.PaymentScheme];

            if (account.PaymentSchemeAllowed(request.PaymentScheme) && validator.Validate(account, request))
            {
                account.DeductAmount(request.Amount);
                _accountDataStore.UpdateAccount(account);
            }

            return new MakePaymentResult() { Success = true };
        }
    }
}
