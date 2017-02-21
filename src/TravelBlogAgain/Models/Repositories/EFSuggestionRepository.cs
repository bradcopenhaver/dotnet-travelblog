using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlogAgain.Models.Repositories
{
    public class EFSuggestionRepository : ISuggestionRepository
    {
        TravelBlogAgainContext db = new TravelBlogAgainContext();

        public EFSuggestionRepository(TravelBlogAgainContext connection = null)
        {
            if (connection == null)
            {
                this.db = new TravelBlogAgainContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<Suggestion> Suggestions
        {
            get { return db.Suggestions; } 
        }

        public Suggestion Edit(Suggestion suggestion)
        {
            db.Entry(suggestion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return suggestion;
        }

        public void Remove(Suggestion suggestion)
        {
            db.Suggestions.Remove(suggestion);
            db.SaveChanges();
        }

        public Suggestion Save(Suggestion suggestion)
        {
            db.Suggestions.Add(suggestion);
            db.SaveChanges();
            return suggestion;
        }

        public void DeleteAll()
        {
            var listAll = db.Suggestions.ToList();
            foreach (Suggestion suggestion in listAll)
            {
                db.Remove(suggestion);
            }
            db.SaveChanges();
        }
    }
}
