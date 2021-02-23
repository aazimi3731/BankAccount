// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BankAccount.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BankAccount.Interfaces;
    using BankAccount.Models;

    /// <summary>
    /// Repository for <see cref="RepositoryBaseEF{T}"/>.
    /// </summary>
    /// <typeparam name="T">A class.</typeparam>
    public class RepositoryBaseEF<T> : IRepositoryBaseEF<T>
        where T : EntityBase
    {
        private readonly BankAccountContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{Task}"/> class.
        /// </summary>
        public RepositoryBaseEF(BankAccountContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task Create(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task CreateEntities(List<T> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        /// <inheritdoc/>
        public async Task Update(T entity)
        {
            await Task.FromResult(_context.Set<T>().Update(entity));
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public void DeleteEntities(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        /// <inheritdoc/>
        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        /// <inheritdoc/>
        public async Task<T> FindById(int id, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult((T)_context.Set<T>().Where(p => p.Id == id).FirstOrDefault());
        }
    }
}
