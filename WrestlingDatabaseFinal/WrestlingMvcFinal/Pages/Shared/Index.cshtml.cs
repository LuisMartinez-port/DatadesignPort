using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;
using WrestlingMvcFinal.Models;

namespace WrestlingMvcFinal.Pages.Shared
{
    public class IndexModel : PageModel
    {
        private readonly IMongoCollection<Match> _matches;

        public IndexModel(IMongoCollection<Match> matches)
        {
            _matches = matches;
        }
        public List<Match> Matches { get; set; } = new();
        [BindProperty(SupportsGet = true)] public string? Company { get; set; }
        [BindProperty(SupportsGet = true)] public string? PpvFilter { get; set; } = "";
        [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)] public int PageSize { get; set; } = 75;
        [BindProperty(SupportsGet = true)] public string? SearchWrestler { get; set; } = "";
        public int TotalPages { get; set; }
        public int TotalMatches { get; set; }
        public async Task OnGetAsync()
        {
            await LoadMatches();
        }

      

        private async Task LoadMatches()
        {

            var filter = Builders<Match>.Filter.Empty;
            if (!string.IsNullOrEmpty(Company))
                filter &= Builders<Match>.Filter.Eq(m => m.Company, Company);
            if (!string.IsNullOrEmpty(PpvFilter) && PpvFilter == "yes")
                filter &= Builders<Match>.Filter.Eq(m => m.PpvString, "yes");
            if (!string.IsNullOrEmpty(SearchWrestler))
                filter &= Builders<Match>.Filter.Or(
                    Builders<Match>.Filter.Regex(m => m.Winner, new BsonRegularExpression(SearchWrestler, "i")),
                    Builders<Match>.Filter.Regex(m => m.Loser, new BsonRegularExpression(SearchWrestler, "i"))
                );

            TotalMatches = (int)await _matches.CountDocumentsAsync(filter);
            TotalPages = (int)Math.Ceiling((double)TotalMatches / PageSize);

           
            CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages));

            
            var skip = (CurrentPage - 1) * PageSize;
            Matches = await _matches.Find(filter).Skip(skip).Limit(PageSize).ToListAsync();
        }
    }
}

