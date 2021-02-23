using BankAccount.Helpers;
using BankAccount.Repositories;
using System.Threading.Tasks;

namespace BankAccount.UnitTest
{
    class DataFixture
    {
        public DataFixture()
        {
        }
        public async Task Fixture()
        {
            // Initialize the list of objects and save them into database table.
            await InitializeHelper.SaveDataAsync();
        }

        public async Task Dispose()
        {
            await RepositoryDelation.DeleteData();
        }
    }
}
