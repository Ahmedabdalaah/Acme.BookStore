using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Acme.BookStore.Books;

namespace Acme.BookStore.Books
{
    public interface IBookServices : IApplicationService
    {
        Task<List<BookDTO>> GetListAsync();
        Task<BookDTO> CreateAsync(BookDTO bookItem);
        Task DeleteAsync(Guid id);
    }
}
