// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionTypes.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models.Enums
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of transaction.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionTypes
    {
        /// <summary>
        /// Cash deposit transaction.
        /// </summary>
        DepositCash,

        /// <summary>
        /// Cash withdraw transaction.
        /// </summary>
        WithdrawCash,

        /// <summary>
        /// Withdraw transaction transferred to another account.
        /// </summary>
        WithdrawTrnasfer,

        /// <summary>
        /// Other gender.
        /// </summary>
        Other,
    }
}
