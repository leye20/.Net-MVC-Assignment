using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMovie.Models;
using AspNetCoreMovie.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreMovie.Controllers
{
    public class MovieController : Controller
    {
        // GET: /<controller>/
        private readonly IMovieItemService _movieItemService;
        public async Task<IActionResult> Index() 
        {
            var items = await _movieItemService.GetIncompleteItemsAsync(); // i took out the "s" in the items from the book.
            
            var model = new MovieViewModel()
            {
                Items = items
            };
            return View(model);
        }

        /*[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }*/

    }
}
