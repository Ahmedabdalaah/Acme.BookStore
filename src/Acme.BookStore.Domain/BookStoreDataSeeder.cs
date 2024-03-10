using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book , Guid> _repo;
        public BookStoreDataSeeder(IRepository<Book , Guid> repo)
        {
            _repo = repo;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _repo.GetCountAsync() <= 0)
            {
                await _repo.InsertAsync(
                    new Book
                    {
                        Name = "The war",
                        Type = BookType.history,
                        PublishDate = new DateTime(year: 1990, month: 12, day: 4),
                        Price = 50.60f
                    },
                    autoSave:true
                    );
                await _repo.InsertAsync(
                    new Book
                    {
                        Name = "The Scientific Work",
                        Type = BookType.scinces,
                        PublishDate = new DateTime(year: 2000, month: 3, day: 22),
                        Price = 52.99f
                    },
                    autoSave: true
                    );
            }
        }
    }
}
