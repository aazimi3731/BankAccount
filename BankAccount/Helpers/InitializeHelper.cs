// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitializeHelper.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Common;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BankAccount.DTO;
using BankAccount.Models;
using BankAccount.Repositories;

namespace BankAccount.Helpers
{
    public class InitializeHelper
    {
        /// <summary>
        /// Initialize the list of objects and save them into database table and do the transactions process.
        /// </summary>
        public static async Task SaveDataAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // Initialize the list of objects and save them into database table.
                string filePath = "\\Data\\customers.json";
                var customersDTO = IOHelpers.ReadFromFile<Customer, CustomerDTO>(filePath);

                var repositoryCustomer = new RepositoryCustomer();
                var customers = IOHelpers.EntitiesList<Customer, CustomerDTO>(customersDTO, repositoryCustomer.BusinessToDomainObjectPropertyMap());

                using (var dbContext = new BankAccountContext())
                {
                    var repository = new RepositoryBaseEF<Customer>(dbContext);

                    await repository.CreateEntities(customers).ConfigureAwait(false);

                    await repository.SaveAsync().ConfigureAwait(false);
                }

                filePath = "\\Data\\accounts.json";
                var accountsDTO = IOHelpers.ReadFromFile<Account, AccountDTO>(filePath);

                var repositoryAccount = new RepositoryAccount();
                var accounts = IOHelpers.EntitiesList<Account, AccountDTO>(accountsDTO, repositoryAccount.BusinessToDomainObjectPropertyMap());

                using (var dbContext = new BankAccountContext())
                {
                    var repository = new RepositoryBaseEF<Account>(dbContext);

                    await repository.CreateEntities(accounts).ConfigureAwait(false);

                    await repository.SaveAsync().ConfigureAwait(false);
                }

                if (accountsDTO.Count > 0)
                    await repositoryCustomer.CreateCustomerAccounts(accountsDTO);

                filePath = "\\Data\\phones.json";
                var phonesDTO = IOHelpers.ReadFromFile<PhoneNumber, PhoneNumberDTO>(filePath);

                var repositoryPhone = new RepositoryPhone();
                var phones = IOHelpers.EntitiesList<PhoneNumber, PhoneNumberDTO>(phonesDTO, repositoryPhone.BusinessToDomainObjectPropertyMap());

                if (phonesDTO.Count > 0 && customersDTO.Count > 0)
                    repositoryPhone.UpdateCustomerIds(customersDTO, phones, phonesDTO);

                using (var dbContext = new BankAccountContext())
                {
                    var repository = new RepositoryBaseEF<PhoneNumber>(dbContext);

                    await repository.CreateEntities(phones).ConfigureAwait(false);

                    await repository.SaveAsync().ConfigureAwait(false);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
