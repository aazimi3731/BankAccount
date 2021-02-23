// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyTypes.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models.Enums
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of currency.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyTypes
    {
        /// <summary>
        /// Canadian currency.
        /// </summary>
        CAD,

        /// <summary>
        /// American currency.
        /// </summary>
        USD,

        /// <summary>
        /// Mexican currency.
        /// </summary>
        MXN,

        /// <summary>
        /// Other gender.
        /// </summary>
        Other,
    }
}
