using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books
{
    public class BookServices : ApplicationService, IBookServices
    {
        private readonly IRepository<Book, Guid> _repository;
        public BookServices(IRepository<Book, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<BookDTO> CreateAsync(BookDTO bookItem  )
        {
            var item = await _repository.InsertAsync(
                new Book
                {
                   Name = bookItem.Name,
                   Price = bookItem.Price,
                   PublishDate = bookItem.PublishDate,
                   Type = bookItem.Type
                });
            return new BookDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                PublishDate = item.PublishDate,
                Type = item.Type
            };

        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<BookDTO>> GetListAsync()
        {
            var books = await _repository.GetListAsync();
            return books
                .Select(book => new BookDTO 
                {
                    Id = book.Id,
                    Name = book.Name,
                    Price = book.Price,     
                    PublishDate = book.PublishDate,
                    Type = book.Type,
                }).ToList();
        }
    }
}
