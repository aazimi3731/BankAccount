    // --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountDTO.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.DTO
{
    using BankAccount.Models;
    using BankAccount.Models.Enums;

    /// <summary>
    /// Provides the information for an account.
    /// </summary>
    public class AccountDTO : EntityBase
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// Gets or sets the type of account.
        /// </summary>
        public string AccountType { get; set; } = AccountTypes.Checking.ToString();

        /// <summary>
        /// Gets or sets whether this account is a joined account.
        /// </summary>
        public string AccountJoined { get; set; } = "0";

        /// <summary>
        /// Gets or sets the current account balance.
        /// </summary>
        public string Balance { get; set; }

        /// <summary>
        /// Gets or sets the date that account was opened.
        /// </summary>
        public string OpenedDate { get; set; }

        /// <summary>
        /// Gets or sets the date that account was closed.
        /// </summary>
        public string ClosedDate { get; set; }

        /// <summary>
        /// Gets or sets the customer No.
        /// </summary>
        public string CustomerNo { get; set; }
    }
}
