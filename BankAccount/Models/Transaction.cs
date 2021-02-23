// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Transaction.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models
{
    using BankAccount.Models.Enums;

    /// <summary>
    /// Provides the information for a transaction.
    /// </summary>
    public class Transaction : EntityBase
    {
        /// <summary>
        /// Gets or sets the date of transaction.
        /// </summary>
        public string TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the type of transaction.
        /// </summary>
        public TransactionTypes TransactionType { get; set; } = TransactionTypes.DepositCash;

        /// <summary>
        /// Gets or sets the account number that the transaction is done.
        /// </summary>
        public string TransactionAccountNo { get; set; }

        /// <summary>
        /// Gets or sets the amount of transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyTypes Currency { get; set; } = CurrencyTypes.CAD;

        /// <summary>
        /// Gets or sets the account Id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the customer Id.
        /// </summary>
        public int CustomerId { get; set; }
    }
}
