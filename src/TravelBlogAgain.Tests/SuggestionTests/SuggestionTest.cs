using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBlogAgain.Models;
using Xunit;
using TravelBlogAgain.Controllers;
using TravelBlogAgain.Models.Repositories;

namespace TravelBlogAgain.Tests.SuggestionTests
{
    public class SuggestionTest : IDisposable
    {
        EFSuggestionRepository db = new EFSuggestionRepository(new TestDbContext());

        [Fact]
        public void CanInstantiateASuggestion()
        {
            Suggestion mySuggestion = new Suggestion("Go EF yourself, Dotnet", "Like really");

            Assert.IsType<Suggestion>(mySuggestion);
        }

        [Fact]
        public void SavesSuggestionToDBTest()
        {
            SuggestionsController cntrl = new SuggestionsController(db);
            Suggestion newSuggestion = new Suggestion("Go EF yourself, Dotnet", "Like for serious");

            cntrl.Create(newSuggestion);

            Assert.Equal(newSuggestion, db.Suggestions.FirstOrDefault(s => s.Id == newSuggestion.Id));
        }

        public void Dispose()
        {
            db.DeleteAll();
        }
    }
}
