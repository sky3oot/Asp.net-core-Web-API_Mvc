using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pract.API.Configurations;
using Pract.API.Models;
using Pract.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pract.API.Services
{
    public class BookService : IBookService
    {

        private readonly IMongoCollection<Books> _book;
        private readonly BooksConfiguration _settings;
        public BookService(IOptions<BooksConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _book = database.GetCollection<Books>(_settings.BooksCollectionName);
        }
        public async Task<Books> CreateAsync(Books book)
        {
            await _book.InsertOneAsync(book);
            return book;
        }

        public async Task DeleteAsync(string id)
        {
            await _book.DeleteOneAsync(c => c.id == id);
        }

        public async Task<List<Books>> GetAllAsync()
        {
            return await _book.Find(c => true).ToListAsync();
        }

        public async Task<Books> GetByIdAsync(string id)
        {
            return await _book.Find<Books>(c => c.id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Books book)
        {
            await _book.ReplaceOneAsync(c => c.id == id, book);
        }
    }
}
