// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberTypes.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models.Enums
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The supported phone number types.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PhoneNumberTypes
    {
        /// <summary>
        /// Mobile phone.
        /// </summary>
        Mobile,

        /// <summary>
        /// Home phone.
        /// </summary>
        Home,

        /// <summary>
        /// Work phone.
        /// </summary>
        Work,

        /// <summary>
        /// Other phone.
        /// </summary>
        Other,
    }
}
