// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryAccount.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Repositories
{
    using System;
    using System.Collections.Generic;
    using BankAccount.Helpers;
    using BankAccount.Interfaces;

    /// <summary>
    /// Repository for <see cref="RepositoryAccount"/>.
    /// </summary>
    public class RepositoryAccount : IRepository
    {
        /// <inheritdoc/>
        public Dictionary<string, DomainObjectItem> BusinessToDomainObjectPropertyMap()
        {
            Dictionary<string, DomainObjectItem> map = new Dictionary<string, DomainObjectItem>(StringComparer.InvariantCultureIgnoreCase)
            {
                /* map is logic business model of AccountDTO to database domain model of Customer*/
                { "Id", new DomainObjectItem { DomainObjectPropertyName = "Id" }},
                { "AccountNo", new DomainObjectItem { DomainObjectPropertyName = "AccountNo" } },
                { "AccountType", new DomainObjectItem { DomainObjectPropertyName = "AccountType" } },
                { "AccountJoined", new DomainObjectItem { DomainObjectPropertyName = "AccountJoined" } },
                { "Balance", new DomainObjectItem { DomainObjectPropertyName = "Balance" } },
                { "OpenedDate", new DomainObjectItem { DomainObjectPropertyName = "OpenedDate" } },
                { "ClosedDate", new DomainObjectItem { DomainObjectPropertyName = "ClosedDate" } },
                { "CreatedDate", new DomainObjectItem { DomainObjectPropertyName = "CreatedDate" } },
                { "LastModifiedDate", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedDate" } },
                { "CreatedBy", new DomainObjectItem { DomainObjectPropertyName = "CreatedBy" } },
                { "LastModifiedBy", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedBy" } },
            };

            return map;
        }
    }
}
