using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data
{
    public class AccountDataStore : IAccountDataStore
    {
        private List<Account> _dummyAccounts =
            new()
            {
                new(1, AccountStatus.Live, AllowedPaymentSchemes.BankToBankTransfer)
            };

        public Account GetAccount(int accountNumber)
        {
            return _dummyAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
