using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMovie.Models;
//using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMovie.Services
{
    public class MovieItemServices : IMovieItemServices
    {
        private readonly ApplicationDbContext _context;
        public MovieItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MovieItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items
            .Where(x => x.IsDone == false)
            .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(MovieItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.ReleaseDate = DateTime.Now.AddDays(1);
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
