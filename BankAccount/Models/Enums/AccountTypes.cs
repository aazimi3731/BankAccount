// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountTypes.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models.Enums
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of account.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountTypes
    {
        /// <summary>
        /// Checking account.
        /// </summary>
        Checking,

        /// <summary>
        /// Saving account.
        /// </summary>
        Saving,

        /// <summary>
        /// Other account.
        /// </summary>
        Other,
    }
}
