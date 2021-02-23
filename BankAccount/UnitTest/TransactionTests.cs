// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionTests.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using BankAccount.UnitTest.Helpers;
using System.Threading.Tasks;
using Xunit;

namespace BankAccount.UnitTest
{
    /// <summary>
    /// Test the transactions.
    /// </summary>
    [Collection("Sequential")]
    public class TransactionTests
    {
        /// <summary>
        /// Transaction 1.
        /// </summary>
        [Fact(DisplayName = "Transaction 1")]
        public async Task Transaction1()
        {
            var dataFixture = new DataFixture();
            await dataFixture.Fixture();

            string filePath = "\\Data\\UnitTestData\\transaction1.json";

            var balances = await TransactionHelper.Transaction(filePath);

            await dataFixture.Dispose();

            decimal[] balanceExpect = new decimal[balances.Count];
            balances.Values.CopyTo(balanceExpect, 0);

            Assert.Equal(balanceExpect[0], (decimal)700.0);
        }

        /// <summary>
        /// Transaction 2.
        /// </summary>
        [Fact(DisplayName = "Transaction 2")]
        public async Task Transaction2()
        {
            var dataFixture = new DataFixture();
            await dataFixture.Fixture();

            string filePath = "\\Data\\UnitTestData\\transaction2.json";

            var balances = await TransactionHelper.Transaction(filePath);

            await dataFixture.Dispose();

            decimal[] balanceExpect = new decimal[balances.Count];
            balances.Values.CopyTo(balanceExpect, 0);
            Assert.Equal(balanceExpect[0], (decimal)9800.0);
        }

        /// <summary>
        /// Transaction 3.
        /// </summary>
        [Fact(DisplayName = "Transaction 3")]
        public async Task Transaction3()
        {
            var dataFixture = new DataFixture();
            await dataFixture.Fixture();

            string filePath = "\\Data\\UnitTestData\\transaction3.json";

            var balances = await TransactionHelper.Transaction(filePath);

            await dataFixture.Dispose();

            decimal[] balanceExpect = new decimal[balances.Count];
            balances.Values.CopyTo(balanceExpect, 0);
            Assert.Equal(balanceExpect[0], (decimal)17300.0);

            Assert.Equal(balanceExpect[1], (decimal)1497.6);
        }

        /// <summary>
        /// Transaction 4.
        /// </summary>
        [Fact(DisplayName = "Transaction 4")]
        public async Task Transaction4()
        {
            var dataFixture = new DataFixture();
            await dataFixture.Fixture();

            string filePath = "\\Data\\UnitTestData\\transaction4.json";

            var balances = await TransactionHelper.Transaction(filePath);

            await dataFixture.Dispose();

            decimal[] balanceExpect = new decimal[balances.Count];
            balances.Values.CopyTo(balanceExpect, 0);
            Assert.Equal(balanceExpect[0], (decimal)33.75);

            Assert.Equal(balanceExpect[1], (decimal)112554.25);
        }

        /// <summary>
        /// Transaction 5.
        /// </summary>
        [Fact(DisplayName = "Transaction 5")]
        public async Task Transaction5()
        {
            var dataFixture = new DataFixture();
            await dataFixture.Fixture();

            string filePath = "\\Data\\UnitTestData\\transaction5.json";

            var balances = await TransactionHelper.Transaction(filePath);

            await dataFixture.Dispose();

            decimal[] balanceExpect = new decimal[balances.Count];
            balances.Values.CopyTo(balanceExpect, 0);
            Assert.Empty(balanceExpect);
        }
    }
}
