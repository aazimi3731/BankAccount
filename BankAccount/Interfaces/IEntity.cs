// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Interfaces
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the interface for Entity.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        [Key]
        int Id { get; set; }
    }
}
