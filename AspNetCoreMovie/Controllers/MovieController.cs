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
        // private readonly List<string> MovieList = new List<string>(); // method to manipulate string

        private readonly IMovieItemService _movieItemService;

        public MovieController(IMovieItemService movieItemService)
        {
            _movieItemService = movieItemService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _movieItemService.GetIncompleteItemsAsync(); // var replaced with MovieItem
            
            var model = new MovieViewModel()
            {
                Items = items
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(MovieItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _movieItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }

    }
}
