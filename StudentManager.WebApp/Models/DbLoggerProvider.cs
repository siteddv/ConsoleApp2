using Microsoft.Extensions.Options;
using StudentManager.Backend.Contexts;

namespace StudentManager.WebApp.Models
{
    [ProviderAlias("Database")]
    public class DbLoggerProvider : ILoggerProvider
    {
        public readonly DbLoggerOptions Options;
        private readonly AppDbContext _context;

        public DbLoggerProvider(IOptions<DbLoggerOptions> _options,
            AppDbContext context)
        {
            Options = _options.Value; // Stores all the options.
            _context = context;
        }

        /// <summary>
        /// Creates a new instance of the db logger.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(this, _context);
        }

        public void Dispose()
        {
        }
    }
}
