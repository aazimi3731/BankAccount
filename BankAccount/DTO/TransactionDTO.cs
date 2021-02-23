// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionDTO.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.DTO
{
    using BankAccount.Models;
    using BankAccount.Models.Enums;

    /// <summary>
    /// Provides the information for a transaction.
    /// </summary>
    public class TransactionDTO : EntityBase
    {
        /// <summary>
        /// Gets or sets the date of transaction.
        /// </summary>
        public string TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the type of transaction.
        /// </summary>
        public string TransactionType { get; set; } = TransactionTypes.DepositCash.ToString();

        /// <summary>
        /// Gets or sets the account number that the transaction is done.
        /// </summary>
        public string TransactionAccountNo { get; set; }

        /// <summary>
        /// Gets or sets the amount of transaction.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Currency { get; set; } = CurrencyTypes.CAD.ToString();

        /// <summary>
        /// Gets or sets the account no.
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// Gets or sets the customer no.
        /// </summary>
        public string CustomerNo { get; set; }
    }
}
