using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class DomainTests
    {
        [Fact]
        public void Account_DeductAmount_AdjustsBalance()
        {
            // Arrange
            var account = new Account(1, AccountStatus.Live, AllowedPaymentSchemes.BankToBankTransfer);

            // Act
            account.DeductAmount(100);

            // Assert
            Assert.Equal(-100, account.Balance);
        }
    }
}
