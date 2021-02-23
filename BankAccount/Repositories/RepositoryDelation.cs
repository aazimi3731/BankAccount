// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryAccount.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Repositories
{
    using System;
    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;
    using BankAccount.Models;

    /// <summary>
    /// Repository for <see cref="RepositoryDelation"/>.
    /// </summary>
    public class RepositoryDelation
    {
        /// <summary>
        /// Delete all data from the database tables.
        /// </summary>
        public static async Task DeleteData(CancellationToken cancellationToken = default)
        {
            try
            {
                using (var dbContext = new BankAccountContext())
                {
                    var repositoryAccount = new Repositories.RepositoryBaseEF<Account>(dbContext);
                    var accounts = repositoryAccount.Get();
                    repositoryAccount.DeleteEntities(accounts);
                    await repositoryAccount.SaveAsync().ConfigureAwait(false);

                    var repositoryCustomer = new Repositories.RepositoryBaseEF<Customer>(dbContext);
                    var customers = repositoryCustomer.Get();
                    repositoryCustomer.DeleteEntities(customers);
                    await repositoryCustomer.SaveAsync().ConfigureAwait(false);

                    var repositoryCustomerAccount = new Repositories.RepositoryBaseEF<CustomerAccount>(dbContext);
                    var customerAccounts = repositoryCustomerAccount.Get();
                    repositoryCustomerAccount.DeleteEntities(customerAccounts);
                    await repositoryCustomerAccount.SaveAsync().ConfigureAwait(false);

                    var repositoryPhone = new Repositories.RepositoryBaseEF<PhoneNumber>(dbContext);
                    var phones = repositoryPhone.Get();
                    repositoryPhone.DeleteEntities(phones);
                    await repositoryPhone.SaveAsync().ConfigureAwait(false);

                    var repositoryTransaction = new Repositories.RepositoryBaseEF<Transaction>(dbContext);
                    var transactions = repositoryTransaction.Get();
                    repositoryTransaction.DeleteEntities(transactions);
                    await repositoryTransaction.SaveAsync().ConfigureAwait(false);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
