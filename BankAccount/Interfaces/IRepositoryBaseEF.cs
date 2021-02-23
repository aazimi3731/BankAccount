// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryBase.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///  Defines the interface for Repository Base, Entity Framework.
    /// </summary>
    /// <typeparam name="T">Class implementing IEntity.</typeparam>
    public interface IRepositoryBaseEF<T>
        where T : IEntityBase
    {
        /// <summary>
        /// Insert an object in a database table.
        /// </summary>
        /// <param name="entity">The object to be inserted.</param>
        /// <returns>The object inserted <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Create(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Insert a list of objects in a database table.
        /// </summary>
        /// <param name="entities">The list of objects to be inserted.</param>
        /// <returns>The objects inserted <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateEntities(List<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an object of a database table.
        /// </summary>
        /// <param name="entity">The object to be updated.</param>
        /// <returns>The result of the update action.</returns>
        Task Update(T entity);

        /// <summary>
        /// Delete an object from a database table.
        /// </summary>
        /// <param name="entity">The object to be deleted.</param>
        /// <returns>The result of the deletation action.</returns>
        void Delete(T entity);

        /// <summary>
        /// Delete objects from a database table.
        /// </summary>
        /// <param name="entities">The objects to be deleted.</param>
        /// <returns>The result of the deletation action.</returns>
        void DeleteEntities(List<T> entities);

        /// <summary>
        /// Save The object that implementing IEntity.
        /// </summary>
        /// <param name="cancellationToken">The token that enables the operation cancellation.</param>
        Task SaveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all objects that implementing IEntity.
        /// </summary>
        /// <returns>The objects found.</returns>
        List<T> Get();

        /// <summary>
        /// Get the object that implementing IEntity.
        /// </summary>
        /// <param name="id">The id of the object that implementing IEntity.</param>
        /// <returns>The object found.</returns>
        Task<T> FindById(int id, CancellationToken cancellationToken = default);
    }
}
