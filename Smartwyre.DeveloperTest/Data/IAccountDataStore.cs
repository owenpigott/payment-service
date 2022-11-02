using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data
{
    public interface IAccountDataStore
    {
        Account GetAccount(int accountNumber);
        void UpdateAccount(Account account);
    }
}