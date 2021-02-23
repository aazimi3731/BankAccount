// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderTypes.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models.Enums
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of gender.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderTypes
    {
        /// <summary>
        /// Male gender.
        /// </summary>
        Male,

        /// <summary>
        /// Female gender.
        /// </summary>
        Female,

        /// <summary>
        /// Other gender.
        /// </summary>
        Other,

        /// <summary>
        /// Prefer not to say.
        /// </summary>
        PreferNotToSay,
    }
}
