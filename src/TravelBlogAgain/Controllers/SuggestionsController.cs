﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlogAgain.Models.Repositories;
using TravelBlogAgain.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlogAgain.Controllers
{
    public class SuggestionsController : Controller
    {
        private ISuggestionRepository suggestionRepo;

        public SuggestionsController(ISuggestionRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.suggestionRepo = new EFSuggestionRepository();
            }
            else
            {
                this.suggestionRepo = thisRepo;
            }
        }


        public ViewResult Index()
        {
            return View(suggestionRepo.Suggestions.ToList());
        }

        public IActionResult Details(int id)
        {
            Suggestion thisSuggestion = suggestionRepo.Suggestions.FirstOrDefault(x => x.Id == id);
            return View(thisSuggestion);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Name, string Description)
        {
            Suggestion newSugg = new Models.Suggestion(Name, Description);
            suggestionRepo.Save(newSugg);
            return Json(newSugg);
        }

        public IActionResult Edit(int id)
        {
            Suggestion thisSuggestion = suggestionRepo.Suggestions.FirstOrDefault(x => x.Id == id);
            return View(thisSuggestion);
        }

        [HttpPost]
        public IActionResult Edit(Suggestion suggestion)
        {
            suggestionRepo.Edit(suggestion);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Suggestion thisSuggestion = suggestionRepo.Suggestions.FirstOrDefault(x => x.Id == id);
            return View(thisSuggestion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Suggestion thisSuggestion = suggestionRepo.Suggestions.FirstOrDefault(x => x.Id == id);
            suggestionRepo.Remove(thisSuggestion);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public int AddUpvote(int id)
        {
            Suggestion thisSuggestion = suggestionRepo.Suggestions.FirstOrDefault(x => x.Id == id);
            thisSuggestion.Upvotes = thisSuggestion.Upvotes + 1;
            suggestionRepo.Edit(thisSuggestion);
            return thisSuggestion.Upvotes;
        }

        [HttpPost]
        public int AddDownvote(int id)
        {
            Suggestion thisSuggestion = suggestionRepo.Suggestions.FirstOrDefault(x => x.Id == id);
            thisSuggestion.Upvotes = thisSuggestion.Upvotes - 1;
            suggestionRepo.Edit(thisSuggestion);
            return thisSuggestion.Upvotes;
        }

    }
}
