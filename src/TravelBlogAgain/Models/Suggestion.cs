using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlogAgain.Models
{
    [Table("Suggestions")]
    public class Suggestion
    {
        public Suggestion()
        {

        }
        public Suggestion(string name, string description, int upvotes = 0, bool visited = false)
        {
            Name = name;
            Description = description;
            Upvotes = upvotes;
            HasBeenVisited = visited;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Upvotes { get; set; }
        public bool HasBeenVisited { get; set; }
    }
}
