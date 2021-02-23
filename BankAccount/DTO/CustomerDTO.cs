// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDTO.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.DTO
{
    using BankAccount.Models;
    using BankAccount.Models.Enums;

    /// <summary>
    /// Provides the information for a customer.
    /// </summary>
    public class CustomerDTO : EntityBase
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
        public string Gender { get; set; } = GenderTypes.PreferNotToSay.ToString();

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
    }
}
