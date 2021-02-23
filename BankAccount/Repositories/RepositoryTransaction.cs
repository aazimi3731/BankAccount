// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryTransaction.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BankAccount.DTO;
    using BankAccount.Helpers;
    using BankAccount.Interfaces;
    using BankAccount.Models;

    /// <summary>
    /// Repository for <see cref="RepositoryTransaction"/>.
    /// </summary>
    public class RepositoryTransaction : IRepository
    {
        public Account Account { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryTransaction"/> class.
        /// </summary>
        public RepositoryTransaction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryTransaction"/> class.
        /// </summary>
        public RepositoryTransaction(Account account)
        {
            Account = account;
        }

        /// <inheritdoc/>
        public Dictionary<string, DomainObjectItem> BusinessToDomainObjectPropertyMap()
        {
            Dictionary<string, DomainObjectItem> map = new Dictionary<string, DomainObjectItem>(StringComparer.InvariantCultureIgnoreCase)
            {
                /* map is logic business model of TransactionDTO to database domain model of Customer*/
                { "Id", new DomainObjectItem { DomainObjectPropertyName = "Id" }},
                { "TransactionDate", new DomainObjectItem { DomainObjectPropertyName = "TransactionDate" } },
                { "TransactionType", new DomainObjectItem { DomainObjectPropertyName = "TransactionType" } },
                { "TransactionAccountNo", new DomainObjectItem { DomainObjectPropertyName = "TransactionAccountNo" } },
                { "Amount", new DomainObjectItem { DomainObjectPropertyName = "Amount" } },
                { "Currency", new DomainObjectItem { DomainObjectPropertyName = "Currency" } },
                { "CreatedDate", new DomainObjectItem { DomainObjectPropertyName = "CreatedDate" } },
                { "LastModifiedDate", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedDate" } },
                { "CreatedBy", new DomainObjectItem { DomainObjectPropertyName = "CreatedBy" } },
                { "LastModifiedBy", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedBy" } },
            };

            return map;
        }

        /// <summary>
        /// Update the list of transactions with the customer and account Ids.
        /// </summary>
        /// <param name="transactions">The transactions to be inserted.</param>
        /// <param name="transactionDTOs">The transactionDTOs to be inserted.</param>
        public async Task UpdateIds(List<Transaction> transactions, List<TransactionDTO> transactionDTOs)
        {
            if (transactions == null)
                throw new ArgumentNullException("The transactions can not be null.");

            if (transactionDTOs == null)
                throw new ArgumentNullException("The transactionDTOs can not be null.");

            try
            {
                var customers = new List<Customer>();
                var accounts = new List<Account>();
                var customerAccounts = new List<CustomerAccount>();

                using (var dbContext = new BankAccountContext())
                {
                    var repositoryCustomer = new Repositories.RepositoryBaseEF<Customer>(dbContext);
                    var repositoryAccount = new Repositories.RepositoryBaseEF<Account>(dbContext);
                    var repositoryCustomerAccount = new Repositories.RepositoryBaseEF<CustomerAccount>(dbContext);

                    customers = await Task.FromResult(repositoryCustomer.Get());
                    accounts = repositoryAccount.Get();
                    customerAccounts = repositoryCustomerAccount.Get();
                }

                if (accounts.Count <= 0)
                    throw new ArgumentNullException("The accounts can not be null.");

                if (customers.Count <= 0)
                    throw new ArgumentNullException("The customers can not be null.");

                if (customerAccounts.Count <= 0)
                    throw new ArgumentNullException("The customerAccounts can not be null.");

                for (int j = 0; j < transactionDTOs.Count; j++)
                {
                    for (int i = 0; i < customers.Count; i++)
                    {
                        if (transactionDTOs[j].CustomerNo.Equals(customers[i].CustomerNo))
                        {
                            transactions[j].CustomerId = customers[i].Id;
                            transactions[j].AccountId = -1;
                            if (customers[i].CustomerAccounts != null)
                            {
                                for (int k = 0; k < accounts.Count; k++)
                                {
                                    if (transactionDTOs[j].AccountNo.Equals(accounts[k].AccountNo))
                                    {
                                        transactions[j].AccountId = accounts[k].Id;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool CheckBalance(decimal amount)
        {
            return Account.Balance > amount;
        }

        public void DepositCash(Transaction transaction)
        {
            var amount = transaction.Amount * ExchangeHelper.CurrencyExchange().GetValueOrDefault(transaction.Currency.ToString());
            Account.Balance += amount;
        }

        public string WithdrawCash(Transaction transaction)
        {
            var amount = transaction.Amount * ExchangeHelper.CurrencyExchange().GetValueOrDefault(transaction.Currency.ToString());
            if (!CheckBalance(amount))
            {
                return "Withdraw amount exceeds account balance.";
            }

            Account.Balance -= amount;
            return string.Empty;
        }

        public string WithdrawTrnasfer(Transaction transaction, Account accountDestination)
        {
            var amount = transaction.Amount * ExchangeHelper.CurrencyExchange().GetValueOrDefault(transaction.Currency.ToString());
            if (!CheckBalance(amount))
            {
                return "Withdraw amount exceeds account balance.";
            }

            Account.Balance -= amount;
            accountDestination.Balance += amount;

            return string.Empty;
        }

        public void report(string message)
        {
            Console.WriteLine(message);
        }
    }
}
