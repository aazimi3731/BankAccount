// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionHelper.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using BankAccount.DTO;
using BankAccount.Helpers;
using BankAccount.Models;
using BankAccount.Models.Enums;
using BankAccount.Repositories;
using BankAccount.UnitTest.Models;

namespace BankAccount.UnitTest.Helpers
{
    public class TransactionHelper
    {
        /// <summary>
        /// Read the list of objects from a file.
        /// </summary>
        public static async Task<Dictionary<string, decimal>> Transaction(string filePath)
        {
            var transactionsDTO = IOHelpers.ReadFromFile<Transaction, TransactionDTO>(filePath, true);

            var repositoryTransaction = new RepositoryTransaction();
            var transactions = IOHelpers.EntitiesList<Transaction, TransactionDTO>(transactionsDTO, repositoryTransaction.BusinessToDomainObjectPropertyMap());

            await repositoryTransaction.UpdateIds(transactions, transactionsDTO);

            Dictionary<string, decimal> balances = new Dictionary<string, decimal>();
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
                    if (transactions[i].TransactionType == TransactionTypes.WithdrawCash ||
                        transactions[i].TransactionType == TransactionTypes.WithdrawTrnasfer)
                        validation = await Validators.Validations.CustomerValidation(transactions[i].AccountId, transactions[i].CustomerId, transactionsDTO[i].AccountNo);

                    var accountDestination = new Account();
                    if (validation)
                    {
                        switch (transactions[i].TransactionType)
                        {
                            case TransactionTypes.DepositCash:
                                repositoryTransaction.DepositCash(transactions[i]);
                                message = string.Format("Account Number: {0} Balance: ${1} CAD", account.AccountNo, account.Balance.ToString());
                                repositoryTransaction.report(message);
                                transactionDone = true;
                                break;
                            case TransactionTypes.WithdrawCash:
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
                            case TransactionTypes.WithdrawTrnasfer:
                                foreach (Account ac in repositoryAccountContext.Get())
                                {
                                    if (ac.AccountNo.Equals(transactions[i].TransactionAccountNo))
                                    {
                                        accountDestination = ac;
                                        break;
                                    }
                                }
                                message = repositoryTransaction.WithdrawTrnasfer(transactions[i], accountDestination);
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

                        if (accountDestination != null && transactions[i].TransactionType == TransactionTypes.WithdrawTrnasfer)
                        {
                            await repositoryAccountContext.Update(accountDestination).ConfigureAwait(false);
                            await repositoryAccountContext.SaveAsync().ConfigureAwait(false);
                        }
                    }
                    
                    if (account != null && account.AccountNo != null && account.AccountNo != string.Empty)
                    {
                        var key = account.AccountNo;
                        if (balances.ContainsKey(key))
                            balances[key] = account.Balance;
                        else
                            balances.Add(key, account.Balance);
                    }

                    if (accountDestination != null && accountDestination.AccountNo != null && accountDestination.AccountNo != string.Empty)
                    {
                        var key = accountDestination.AccountNo;
                        if (balances.ContainsKey(key))
                            balances[key] = accountDestination.Balance;
                        else
                            balances.Add(key, accountDestination.Balance);
                    }
                }
            }
            return balances;
        }
    }
}
