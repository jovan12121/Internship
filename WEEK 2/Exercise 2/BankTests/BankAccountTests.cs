using BankAccountNS;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [Timeout(1000)]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expectedBalance = 7.44;
            BankAccount account = new BankAccount("John Doe", beginningBalance);

            account.Debit(debitAmount);

            double actualBalance = account.Balance;
            Assert.AreEqual(expectedBalance, actualBalance);

        }
        [TestMethod]
        public void Debit_AmountLessThanZero_ThrowsException()
        {
            double beginningAmount = 52.2;
            double debitAmount = -5;
            BankAccount account = new BankAccount("John Doe", beginningAmount);

            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown");


        }

        [TestMethod]
        public void Debit_AmountMoreThanCurrentBalance_ThrowsException()
        {
            double beginningAmount = 52.2;
            double debitAmount = 100;
            BankAccount account = new BankAccount("John Doe", beginningAmount);

            try
            {
                account.Debit(debitAmount);
            }
            catch(System.ArgumentOutOfRangeException e) 
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown");

        }

    }
}