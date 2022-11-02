namespace Smartwyre.DeveloperTest.Types
{
    public class Account
    {
        private readonly int _accountNumber;
        private AccountStatus _status;
        private AllowedPaymentSchemes _allowedPaymentSchemes;
        private decimal _balance;

        public Account(
            int accountNumber,
            AccountStatus status,
            AllowedPaymentSchemes allowedPaymentSchemes)
        {
            _accountNumber = accountNumber;
            _status = status;
            _allowedPaymentSchemes = allowedPaymentSchemes;
            _balance = 0;
        }

        public int AccountNumber
            => _accountNumber;

        public decimal Balance
            => _balance;
        public AccountStatus Status
            => _status;

        public AllowedPaymentSchemes AllowedPaymentSchemes
            => _allowedPaymentSchemes;

        public void DeductAmount(decimal amount)
        {
            _balance -= amount;
        }

        public bool PaymentSchemeAllowed(PaymentScheme scheme)
        {
            return AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.BankToBankTransfer);
        }
    }
}
