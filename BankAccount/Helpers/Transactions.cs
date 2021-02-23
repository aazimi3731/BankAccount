// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Transactions.cs" company="Myself">
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
    public class Transactions
    {
        /// <summary>
        /// Read the list of transactions from file and do them.
        /// </summary>
        public static async Task TransactionProcessAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string filePath = "\\Data\\transactions.json";
                var transactionsDTO = IOHelpers.ReadFromFile<Transaction, TransactionDTO>(filePath);

                var repositoryTransaction = new RepositoryTransaction();
                var transactions = IOHelpers.EntitiesList<Transaction, TransactionDTO>(transactionsDTO, repositoryTransaction.BusinessToDomainObjectPropertyMap());

                await repositoryTransaction.UpdateIds(transactions, transactionsDTO);

                using (var dbContext = new BankAccountContext())
                {
                    var repositoryAccountContext = new RepositoryBaseEF<Account>(dbContext);

                    for (int i = 0; i < transactions.Count; i++)
                    {
                        var transactionDone = false;

                        var account = await repositoryAccountContext.FindById(transactions[i].AccountId);
                        repositoryTransaction = new RepositoryTransaction(account);

                        var message = string.Empty;
                        message = string.Format("Ouput {0}:", (i + 1).ToString());
                        repositoryTransaction.report(message);

                        var validation = true;
                        if (transactions[i].TransactionType == Models.Enums.TransactionTypes.WithdrawCash ||
                            transactions[i].TransactionType == Models.Enums.TransactionTypes.WithdrawTrnasfer)
                            validation = await Validators.Validations.CustomerValidation(transactions[i].AccountId, transactions[i].CustomerId, transactionsDTO[i].AccountNo);

                        var accountDestination = new Account();
                        if (validation)
                        {
                            switch (transactions[i].TransactionType)
                            {
                                case Models.Enums.TransactionTypes.DepositCash:
                                    repositoryTransaction.DepositCash(transactions[i]);
                                    message = string.Format("Account Number: {0} Balance: ${1} CAD", account.AccountNo, account.Balance.ToString());
                                    repositoryTransaction.report(message);
                                    transactionDone = true;
                                    break;
                                case Models.Enums.TransactionTypes.WithdrawCash:
                                    message = repositoryTransaction.WithdrawCash(transactions[i]);
                                    if (message.Equals(string.Empty))
                                    {
                                        message = string.Format("Account Number: {0} Balance: ${1} CAD", account.AccountNo, account.Balance.ToString());
                                        repositoryTransaction.report(message);
                                        transactionDone = true;
                                    }
                                    else
                                    {
                                        repositoryTransaction.report(message);
                                        transactionDone = false;
                                    }
                                    break;
                                case Models.Enums.TransactionTypes.WithdrawTrnasfer:
                                    foreach (Account ac in repositoryAccountContext.Get())
                                    {
                                        if (ac.AccountNo.Equals(transactions[i].TransactionAccountNo))
                                        {
                                            accountDestination = ac;
                                            break;
                                        }
                                    }
                                    message  = repositoryTransaction.WithdrawTrnasfer(transactions[i], accountDestination);
                                    if (message.Equals(string.Empty))
                                    {
                                        message = string.Format("Account Number: {0} Balance: ${1} CAD Account Number: {2} Balance: ${3} CAD",
                                            account.AccountNo, account.Balance, accountDestination.AccountNo, accountDestination.Balance);
                                        repositoryTransaction.report(message);
                                        transactionDone = true;
                                    }
                                    else
                                    {
                                        repositoryTransaction.report(message);
                                        transactionDone = false;
                                    }
                                    break;
                            }
                        }

                        if (transactionDone)
                        {
                            var repositoryTransactionContext = new RepositoryBaseEF<Transaction>(dbContext);
                            await repositoryTransactionContext.Create(transactions[i]).ConfigureAwait(false);
                            await repositoryTransactionContext.SaveAsync().ConfigureAwait(false);

                            await repositoryAccountContext.Update(account).ConfigureAwait(false);
                            await repositoryAccountContext.SaveAsync().ConfigureAwait(false);

                            if (accountDestination != null && transactions[i].TransactionType == Models.Enums.TransactionTypes.WithdrawTrnasfer)
                            {
                                await repositoryAccountContext.Update(accountDestination).ConfigureAwait(false);
                                await repositoryAccountContext.SaveAsync().ConfigureAwait(false);
                            }
                        }
                    }
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
