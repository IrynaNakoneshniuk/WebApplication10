using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication10.Models;
using WebApplMVC_EntityFramework.Services;

namespace WebApplication10.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IDatabaseHandlerRepository _repository;

        public DeleteModel(IDatabaseHandlerRepository repository)
        {
           _repository = repository;
        }

        [BindProperty]
      public BooksNew BooksNew { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksnew = await _repository.GetDetailsBookNew(id);

            if (booksnew == null)
            {
                return NotFound();
            }
            else 
            {
                BooksNew = booksnew;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _repository.DeleteConfirmed(id);

            return RedirectToPage("./Index");
        }
    }
}
