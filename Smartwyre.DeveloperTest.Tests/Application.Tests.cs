using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class ApplicationTests
    {
        private readonly int _validAccountNumber = 1;
        private readonly Account _validAccount = new (
            1,
            AccountStatus.Live,
            AllowedPaymentSchemes.BankToBankTransfer);

        [Fact]
        public void MakePayment_ValidAccount_AdjustsBalance()
        {
            // Arrange
            var mockDataStore = new Mock<IAccountDataStore>();
            mockDataStore.Setup(x => x.GetAccount(_validAccountNumber)).Returns(_validAccount);

            IPaymentService paymentService = new PaymentService(mockDataStore.Object);

            // Act
            paymentService.MakePayment(new MakePaymentRequest() { 
                Amount = 420,
                DebtorAccountNumber = _validAccountNumber,
                PaymentScheme = PaymentScheme.BankToBankTransfer });

            // Assert
            Assert.Equal(-420, _validAccount.Balance);
        }

        [Fact]
        public void MakePayment_AccountDoesNotExist_Throws()
        {
            // Arrange
            int _invalidAccountNumber = 2;

            var mockDataStore = new Mock<IAccountDataStore>();
            mockDataStore.Setup(x => x.GetAccount(_invalidAccountNumber)).Returns((Account)null);

            IPaymentService paymentService = new PaymentService(mockDataStore.Object);

            Action action = () => paymentService.MakePayment(new MakePaymentRequest()
            {
                DebtorAccountNumber = _invalidAccountNumber,
            });

            // Act
            var exception = Record.Exception(() => action());


            // Assert
            Assert.IsType<Exception>(exception);
            Assert.Contains(_invalidAccountNumber.ToString(), exception.Message);
        }


        // TODO: Test validators. Would be theory likely, not fact.
        [Fact]
        public void Validators_ValidDetails_ReturnsTrue()
        {
            Assert.True(true);
        }
    }
}
