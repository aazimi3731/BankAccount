// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputData.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using BankAccount.DTO;
using BankAccount.Helpers;
using BankAccount.Models;
using BankAccount.Repositories;
using System.Collections.Generic;
using Xunit;

namespace BankAccount.UnitTest
{
    /// <summary>
    /// Tests the input data.
    /// </summary>
    [Collection("Sequential")]
    public class InputData
    {
        /// <summary>
        /// Customer Data.
        /// </summary>
        [Fact(DisplayName = "Customer Data")]
        public void CustomerData()
        {
            var dataFixture = new DataFixture();
            dataFixture.Fixture().ConfigureAwait(false).GetAwaiter().GetResult();

            // Initialize the list of objects and save them into database table.
            string filePath = "\\Data\\customers.json";
            var customersDTO = IOHelpers.ReadFromFile<Customer, CustomerDTO>(filePath, true);

            var repositoryCustomer = new RepositoryCustomer();
            var customers = IOHelpers.EntitiesList<Customer, CustomerDTO>(customersDTO, repositoryCustomer.BusinessToDomainObjectPropertyMap());

            var customersNew = new List<Customer>();
            using (var dbContext = new BankAccountContext())
            {
                var repository = new RepositoryBaseEF<Customer>(dbContext);

                customersNew = repository.Get();
            }

            dataFixture.Dispose().ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.NotNull(customersNew);

            var count = customers.Count;

            Assert.Equal(customers[count - 1].BirthDate, customersNew[count - 1].BirthDate);
        }

        /// <summary>
        /// Account Data.
        /// </summary>
        [Fact(DisplayName = "Account Data")]
        public void AccountData()
        {
            var dataFixture = new DataFixture();
            dataFixture.Fixture().ConfigureAwait(false).GetAwaiter().GetResult();

            // Initialize the list of objects and save them into database table.
            var filePath = "\\Data\\accounts.json";
            var accountsDTO = IOHelpers.ReadFromFile<Account, AccountDTO>(filePath, true);

            var repositoryAccount = new RepositoryAccount();
            var accounts = IOHelpers.EntitiesList<Account, AccountDTO>(accountsDTO, repositoryAccount.BusinessToDomainObjectPropertyMap());

            var accountsNew = new List<Account>();
            using (var dbContext = new BankAccountContext())
            {
                var repository = new RepositoryBaseEF<Account>(dbContext);

                accountsNew = repository.Get();
            }

            dataFixture.Dispose().ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.NotNull(accountsNew);

            var count = accounts.Count;

            Assert.Equal(accounts[count - 1].AccountNo, accountsNew[count - 1].AccountNo);
        }
    }
}
