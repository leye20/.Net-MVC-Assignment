using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreMovie.Models;

namespace AspNetCoreMovie.Services
{
    public interface IMovieItemService
    {
        Task<MovieItem[]> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(MovieItem newItem);
    }
}
