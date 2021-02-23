// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankAccountContext.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace BankAccount.Models
{
    public class BankAccountContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.;Database=BankAccountDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    }
}
