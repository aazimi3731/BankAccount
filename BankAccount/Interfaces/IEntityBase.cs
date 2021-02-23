// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityBase.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Interfaces
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Defines the interface for create and update properties.
    /// </summary>
    public interface IEntityBase : IEntity
    {
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        [JsonPropertyName("CreatedDate")]
        string CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets User's Last Modified Date.
        /// </summary>
        [JsonPropertyName("LastModifiedDate")]
        string LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets User's Created By.
        /// </summary>
        [JsonPropertyName("CreatedBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets User's Last Modified By.
        /// </summary>
        [JsonPropertyName("LastModifiedBy")]
        public string LastModifiedBy { get; set; }
    }
}
