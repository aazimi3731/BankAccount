// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryPhone.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Repositories
{
    using System;
    using System.Collections.Generic;
    using BankAccount.DTO;
    using BankAccount.Helpers;
    using BankAccount.Models;

    /// <summary>
    /// Repository for <see cref="RepositoryPhone"/>.
    /// </summary>
    public class RepositoryPhone
    {
        /// <inheritdoc/>
        public Dictionary<string, DomainObjectItem> BusinessToDomainObjectPropertyMap()
        {
            Dictionary<string, DomainObjectItem> map = new Dictionary<string, DomainObjectItem>(StringComparer.InvariantCultureIgnoreCase)
            {
                /* map is logic business model of PhoneDTO to database domain model of Customer*/
                { "Id", new DomainObjectItem { DomainObjectPropertyName = "Id" }},
                { "Number", new DomainObjectItem { DomainObjectPropertyName = "Number" } },
                { "PhoneNumberType", new DomainObjectItem { DomainObjectPropertyName = "PhoneNumberType" } },
                { "CreatedDate", new DomainObjectItem { DomainObjectPropertyName = "CreatedDate" } },
                { "LastModifiedDate", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedDate" } },
                { "CreatedBy", new DomainObjectItem { DomainObjectPropertyName = "CreatedBy" } },
                { "LastModifiedBy", new DomainObjectItem { DomainObjectPropertyName = "LastModifiedBy" } },
            };

            return map;
        }

        /// <summary>
        /// Update the list of phones with the customer Ids.
        /// </summary>
        /// <param name="phones">The phones to be inserted.</param>
        /// <param name="phonesDTO">The phonesDTO to be inserted.</param>
        /// <param name="customersDTO">The customersDTO to be inserted.</param>
        public void UpdateCustomerIds(List<CustomerDTO> customersDTO, List<PhoneNumber> phones, List<PhoneNumberDTO> phonesDTO)
        {
            if (phones == null)
                throw new ArgumentNullException("The phones can not be null.");

            if (phonesDTO == null)
                throw new ArgumentNullException("The phonesDTO can not be null.");

            if (customersDTO == null)
                throw new ArgumentNullException("The customersDTO can not be null.");

            try
            {
                var customers = new List<Customer>();

                using (var dbContext = new BankAccountContext())
                {
                    var repositoryCustomer = new Repositories.RepositoryBaseEF<Customer>(dbContext);

                    customers = repositoryCustomer.Get();
                    if (customers.Count <= 0)
                        throw new ArgumentNullException("The customers can not be null.");
                }

                for (int j = 0; j < phonesDTO.Count; j++)
                    {
                        for (int i = 0; i < customers.Count; i++)
                        {
                            if (phonesDTO[j].CustomerNo.Equals(customersDTO[i].CustomerNo))
                            {
                                phones[j].CustomerId = customers[i].Id;
                                break;
                            }
                        }
                    }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
