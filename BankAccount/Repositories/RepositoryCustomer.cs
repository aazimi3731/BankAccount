// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryCustomer.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Threading.Tasks;
    using BankAccount.DTO;
    using BankAccount.Helpers;
    using BankAccount.Interfaces;
    using BankAccount.Models;

    /// <summary>
    /// Repository for <see cref="RepositoryCustomer"/>.
    /// </summary>
    public class RepositoryCustomer : IRepository
    {
        /// <inheritdoc/>
        public Dictionary<string, DomainObjectItem> BusinessToDomainObjectPropertyMap()
        {
            Dictionary<string, DomainObjectItem> map = new Dictionary<string, DomainObjectItem>(StringComparer.InvariantCultureIgnoreCase)
            {
                /* map is logic business model of CustomerDTO to database domain model of Customer*/
                { "Id", new DomainObjectItem { DomainObjectPropertyName = "Id" }},
                { "CustomerNo", new DomainObjectItem { DomainObjectPropertyName = "CustomerNo" } },
                { "FirstName", new DomainObjectItem { DomainObjectPropertyName = "FirstName" } },
                { "LastName", new DomainObjectItem { DomainObjectPropertyName = "LastName" } },
                { "BirthDate", new DomainObjectItem { DomainObjectPropertyName = "BirthDate" } },
                { "Gender", new DomainObjectItem { DomainObjectPropertyName = "Gender" } },
                { "Language", new DomainObjectItem { DomainObjectPropertyName = "Language" } },
                { "Address", new DomainObjectItem { DomainObjectPropertyName = "Address" } },
                { "Email", new DomainObjectItem { DomainObjectPropertyName = "Email" } },
                { "PhoneNumber", new DomainObjectItem { DomainObjectPropertyName = "PhoneNumber" } },
                { "CustomerDate", new DomainObjectItem { DomainObjectPropertyName = "CustomerDate" } },
                { "CreatedDate", new DomainObjectItem { DomainObjectPropertyName = "CreatedDate" } },
                { "LastModifiedDate", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedDate" } },
                { "CreatedBy", new DomainObjectItem { DomainObjectPropertyName = "CreatedBy" } },
                { "LastModifiedBy", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedBy" } },
            };

            return map;
        }

        /// <summary>
        /// Insert a list of customrAccounts in the database table.
        /// </summary>
        /// <param name="accountsDTO">The accountsDTO to be inserted.</param>
        public async Task CreateCustomerAccounts(List<AccountDTO> accountsDTO)
        {
            if (accountsDTO == null)
                throw new ArgumentNullException("The accountsDTO can not be null.");

            var accounts = new List<Account>();
            var customers = new List<Customer>();

            using (var dbContext = new BankAccountContext())
            {
                var repositoryAccount = new Repositories.RepositoryBaseEF<Account>(dbContext);
                var repositoryCustomer = new Repositories.RepositoryBaseEF<Customer>(dbContext);

                accounts = repositoryAccount.Get();
                if (accounts.Count <= 0)
                    throw new ArgumentNullException("The accounts can not be null.");

                customers = repositoryCustomer.Get();
                if (customers.Count <= 0)
                    throw new ArgumentNullException("The customers can not be null.");
            }

            try
            {
                using (var dbContext = new BankAccountContext())
                {
                    var repository = new RepositoryBaseEF<CustomerAccount>(dbContext);

                    var customerAccounts = new List<CustomerAccount>();

                    for (int j = 0; j < accountsDTO.Count; j++)
                    {
                        for (int i = 0; i < customers.Count; i++)
                        {
                            if (accountsDTO[j].CustomerNo.Equals(customers[i].CustomerNo))
                            {
                                var customerAccount = new CustomerAccount();
                                customerAccount.CustomerId = customers[i].Id;
                                customerAccount.AccountId = accounts[j].Id;
                                customerAccount.CreatedDate = DateTime.Now.ToString();
                                customerAccount.CreatedBy = "Aziz Azimi";
                                customerAccounts.Add(customerAccount);
                                break;
                            }
                        }
                    }

                    try
                    {
                        await repository.CreateEntities(customerAccounts);

                        await repository.SaveAsync();
                    }
                    catch (DbException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
