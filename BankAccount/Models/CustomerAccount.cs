// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerAccount.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models
{
    /// <summary>
    /// Provides the information for the relationship between a customer and an account.
    /// </summary>
    public class CustomerAccount : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAccount"/> class.
        /// </summary>
        public CustomerAccount()
        {
            CustomerId = 0;
            AccountId = 0;
        }

        /// <summary>
        /// Gets or sets customer Id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets customer object.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets account Id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets account object.
        /// </summary>
        public Account Account { get; set; }
    }
}
