// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BankAccount.Interfaces;

    /// <summary>
    /// Defines the class for create and update properties.
    /// </summary>
    [Serializable]
    public class EntityBase : IEntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        public EntityBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        /// <param name="createdDate">The creation date.</param>
        /// <param name="createdBy">The created by property.</param>
        /// <param name="lastModifiedDate">The last modified date.</param>
        /// <param name="lastModifiedBy">The last modified by property.</param>
        public EntityBase(string createdDate, string createdBy, string lastModifiedDate, string lastModifiedBy)
        {
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.LastModifiedDate = lastModifiedDate;
            this.LastModifiedBy = lastModifiedBy;
        }

        /// <inheritdoc/>
        [Key]
        public int Id { get; set; }

        /// <inheritdoc/>
        public string CreatedDate { get; set; }

        /// <inheritdoc/>
        public string LastModifiedDate { get; set; }

        /// <inheritdoc/>
        public string CreatedBy { get; set; }

        /// <inheritdoc/>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Sets all the properties of the instance.
        /// </summary>
        /// <param name="eb">An instance of <see cref="EntityBase"/>.</param>
        public void SetEntitBaseValues(EntityBase eb)
        {
            if (eb is null)
            {
                throw new System.ArgumentNullException(nameof(eb));
            }

            this.CreatedDate = eb.CreatedDate;
            this.CreatedBy = eb.CreatedBy;
            this.LastModifiedDate = eb.LastModifiedDate;
            this.LastModifiedBy = eb.LastModifiedBy;
        }
    }
}
