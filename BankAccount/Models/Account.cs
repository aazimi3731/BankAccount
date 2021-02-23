// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Account.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models
{
    using System.Collections.Generic;
    using BankAccount.Models.Enums;

    /// <summary>
    /// Provides the information for an account.
    /// </summary>
    public class Account : EntityBase
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// Gets or sets the type of account.
        /// </summary>
        public AccountTypes AccountType { get; set; } = AccountTypes.Checking;

        /// <summary>
        /// Gets or sets whether this account is a joined account.
        /// </summary>
        public byte AccountJoined { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current account balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the date that account was opened.
        /// </summary>
        public string OpenedDate { get; set; }

        /// <summary>
        /// Gets or sets the date that account was closed.
        /// </summary>
        public string ClosedDate { get; set; }

        /// <summary>
        /// Gets or sets the list of customerAccount.
        /// </summary>
        public List<CustomerAccount> CustomerAccounts { get; set; }

        /// <summary>
        /// Gets or sets the list of transactions.
        /// </summary>
        public List<Transaction> Transactions { get; set; }
    }
}
