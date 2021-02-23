// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Balance.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.UnitTest.Models
{
    using System;

    /// <summary>
    /// The class is responsible for account balances.
    /// </summary>
    [Serializable]
    public class Balance
    {
        /// <summary>
        /// Gets or sets an account balance1.
        /// </summary>
        public decimal Balance1 { get; set; } = (decimal)0.0;

        /// <summary>
        /// Gets or sets an account balance2.
        /// </summary>
        public decimal Balance2 { get; set; } = (decimal)0.0;
    }
}
