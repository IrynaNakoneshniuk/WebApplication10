﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;
using WebApplMVC_EntityFramework.Services;

namespace WebApplication10.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IDatabaseHandlerRepository _repository;

        public DetailsModel(IDatabaseHandlerRepository repository)
        {
            _repository = repository;
        }

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
    }
}
