// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Interfaces
{
    using BankAccount.Helpers;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the interface for create and update properties.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        ///  Property map dictionary for logic business model to database domain model.
        /// </summary>
        /// <returns>String dictionary associating the logic business entity properties to the DB column names.</returns>
        Dictionary<string, DomainObjectItem> BusinessToDomainObjectPropertyMap();
    }
}
