using WebApplication10.Models;


namespace WebApplMVC_EntityFrameworkDZ.Services
{
    public interface IBooksPageSorterFilter
    {
        Task<IQueryable<BooksNew>> FilteringResult(string nameFilter, string SearchString, IQueryable<BooksNew> books);
    }
}