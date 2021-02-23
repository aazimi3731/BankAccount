// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumber.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models
{
    using System;
    using BankAccount.Models.Enums;

    /// <summary>
    /// The class is responsible for phone numbers representation.
    /// </summary>
    [Serializable]
    public class PhoneNumber : EntityBase
    {
        /// <summary>
        /// Gets or sets a value of the phone number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets a value of the phone number type.
        /// </summary>
        public PhoneNumberTypes PhoneNumberType { get; set; }

        /// <summary>
        /// Gets or sets customer Id.
        /// </summary>
        public int CustomerId { get; set; }
    }
}
