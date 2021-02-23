// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberDTO.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.DTO
{
    using BankAccount.Models;
    using System;

    /// <summary>
    /// The class is responsible for phone numbers representation.
    /// </summary>
    [Serializable]
    public class PhoneNumberDTO : EntityBase
    {
        /// <summary>
        /// Gets or sets a value of the phone number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets a value of the phone number type.
        /// </summary>
        public string PhoneNumberType { get; set; }

        /// <summary>
        /// Gets or sets customer No.
        /// </summary>
        public string CustomerNo { get; set; }
    }
}
