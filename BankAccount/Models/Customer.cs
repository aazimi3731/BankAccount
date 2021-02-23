// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models
{
    using System.Collections.Generic;
    using BankAccount.Models.Enums;

    /// <summary>
    /// Provides the information for a customer.
    /// </summary>
    public class Customer : EntityBase
    {
        /// <summary>
        /// Gets or sets the customer number.
        /// </summary>
        public string CustomerNo { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the type of gender.
        /// </summary>
        public GenderTypes Gender { get; set; } = GenderTypes.PreferNotToSay;

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the date that became customer.
        /// </summary>
        public string CustomerDate { get; set; }

        /// <summary>
        /// Gets or sets the list of phone number.
        /// </summary>
        public List<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the list of customerAccount.
        /// </summary>
        public List<CustomerAccount> CustomerAccounts { get; set; }

        /// <summary>
        /// Gets or sets the list of transactions.
        /// </summary>
        public List<Transaction> Transactions { get; set; }
    }
}
