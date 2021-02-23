// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validations.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Models;
using BankAccount.Repositories;

namespace BankAccount.Validators
{
    public class Validations
    {
        /// <summary>
        /// Validate customer of an account.
        /// </summary>
        public static async Task<bool> CustomerValidation(int accountId, int customerId, string accountNo)
        {
            using (var dbContext = new BankAccountContext())
            {
                var repositoryCustomer = new RepositoryBaseEF<Customer>(dbContext);
                var customer = await repositoryCustomer.FindById(customerId).ConfigureAwait(false);

                var repositoryAccount = new RepositoryBaseEF<Account>(dbContext);
                if (repositoryAccount.Get().Any(a => a.Id == accountId))
                    return true;

                var message = string.Format("Customer ID: {0}, You do not allow to withdraw money from Account No.: {1}", customer.CustomerNo, accountNo);
                Console.WriteLine(message);
                return false;
            }
        }
    }
}
