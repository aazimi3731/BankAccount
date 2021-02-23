// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Myself">
// All content copyright © 2021 - 2022 Myself.
// All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using BankAccount.Helpers;
using BankAccount.Repositories;

namespace BankAccount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainProcess().ConfigureAwait(false).GetAwaiter().GetResult();

            Console.WriteLine("The Process was finished");

            Console.ReadLine();
        }

        /// <summary>
        /// Initialize the list of objects and save them into database table and do the transactions process.
        /// </summary>
        public static async Task MainProcess(CancellationToken cancellationToken = default)
        {
            try
            {
                // Initialize the list of objects and save them into database table.
                await InitializeHelper.SaveDataAsync().ConfigureAwait(false);

                // Transaction Processes.
                await Transactions.TransactionProcessAsync().ConfigureAwait(false);

                Console.WriteLine("The Transaction Processes were done\n\n\n\n");

                // Delation Process.
                Console.WriteLine("To execute the program again, you must delete the data from database tables.");
                Console.WriteLine("Do you want to delete the data from database tables? (Y/N)");
                var request = Console.ReadLine();

                if (request.Length > 1)
                    request = request.Substring(0, 1);

                if (request.ToLowerInvariant().Equals("y"))
                    await RepositoryDelation.DeleteData().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
