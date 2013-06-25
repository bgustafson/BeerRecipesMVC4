using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using ShipCompliantMVC.Models;

namespace ShipCompliantMVC.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipeDbContext _dbRecipe = new RecipeDbContext();
        private readonly IngredientDbContext _dbIngredient = new IngredientDbContext();
        private readonly StepDbContext _dbStep = new StepDbContext();

        //
        // GET: /Recipes/

        public ActionResult Index()
        {
            return View(_dbRecipe.Recipes.ToList());
        }

        //
        // GET: /Recipes/Details/5

        public ActionResult Details(int id = 0)
        {
            Recipe recipe = _dbRecipe.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // GET: /Recipes/Create

        public ActionResult Create()
        {
            var listStyles = new SelectList(new[]
                                          {
                                            new {ID="1",Name="Amber Lager"},
                                            new {ID="2",Name="American Lager"},
                                            new {ID="3",Name="Barley Wine"},
                                            new {ID="4",Name="Belgian Ale"},
                                            new {ID="5",Name="Bitters"},
                                            new {ID="6",Name="Bock"},
                                            new {ID="7",Name="Brown Ale"},
                                            new {ID="8",Name="California Common"},
                                            new {ID="9",Name="Cider"},
                                            new {ID="10",Name="Fruit Beer"},
                                            new {ID="11",Name="IPA"},
                                            new {ID="12",Name="Mead"},
                                            new {ID="13",Name="Munich Dunkel"},
                                            new {ID="14",Name="Pale Ale"},
                                            new {ID="15",Name="Pilsner"},
                                            new {ID="16",Name="Porter"},
                                            new {ID="17",Name="Scottish"},
                                            new {ID="18",Name="Stout"},
                                            new {ID="19",Name="Wheat/Weizen"},
                                            new {ID="20",Name="Wit"}
                                          },
                                        "Name", "Name", 1);
            ViewData["listStyles"] = listStyles;

            var listType = new SelectList(new[]
                                          {
                                            new {ID="1",Name="All Grain"},
                                            new {ID="2",Name="Extract"},
                                            new {ID="3",Name="Partial Mash"}
                                          },
                                        "Name", "Name", "Extract");
            ViewData["listType"] = listType;
            return View();
        }

        //
        // POST: /Recipes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recipe recipe, IEnumerable<Ingredient> ingredients, IEnumerable<Step> steps)
        {
            if (ModelState.IsValid)
            {
                _dbRecipe.Recipes.Add(recipe);
                _dbRecipe.SaveChanges();

                if (steps != null)
                {
                    foreach (var step in steps)
                    {
                        _dbStep.Steps.Add(step);
                        _dbStep.SaveChanges();
                    }
                }


                if (ingredients != null)
                {
                    foreach (var ingredient in ingredients)
                    {
                        _dbIngredient.Ingredients.Add(ingredient);
                        _dbIngredient.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        //
        // GET: /Recipes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Recipe recipe = _dbRecipe.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // POST: /Recipes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _dbRecipe.Entry(recipe).State = EntityState.Modified;
                _dbRecipe.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        //
        // GET: /Recipes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Recipe recipe = _dbRecipe.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // POST: /Recipes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = _dbRecipe.Recipes.Find(id);
            _dbRecipe.Recipes.Remove(recipe);
            _dbRecipe.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _dbRecipe.Dispose();
            base.Dispose(disposing);
        }

        //Search Function
        public ActionResult SearchIndex(string recipeStyle, string beerName, string recipeType)
        {
            var styleList = new List<string>();
            var typeList = new List<string>();

            var genreQry = from d in _dbRecipe.Recipes
                           orderby d.Name
                           select d.Style;
            styleList.AddRange(genreQry.Distinct());
            ViewBag.recipeStyle = new SelectList(styleList);

            var typeQry = from d in _dbRecipe.Recipes
                           orderby d.Name
                           select d.MashType;
            typeList.AddRange(typeQry.Distinct());
            ViewBag.recipeType = new SelectList(typeList);

            var recipes = from m in _dbRecipe.Recipes
                         select m;

            if(!String.IsNullOrEmpty(beerName))
                return View(recipes.Where(s => s.Name.Contains(beerName)));
            if (!String.IsNullOrEmpty(recipeStyle) && !String.IsNullOrEmpty(recipeType))
                return View(recipes.Where(x => x.Style == recipeStyle && x.MashType == recipeType));
            if (!String.IsNullOrEmpty(recipeStyle) && String.IsNullOrEmpty(recipeType))
                return View(recipes.Where(x => x.Style == recipeStyle));
            if (!String.IsNullOrEmpty(recipeType) && String.IsNullOrEmpty(recipeStyle))
                return View(recipes.Where(m => m.MashType == recipeType));
               
            return View(recipes);
        }

        public PartialViewResult BlankEditorRowIngredient()
        {
            var list = new SelectList(new[]
                                          {
                                            new {ID="1",Name="Package"},
                                            new {ID="2",Name="oz"},
                                            new {ID="3",Name="lbs"}
                                          },
                                        "Name", "Name", "Package");
            ViewData["listUnit"] = list;

            return PartialView("Ingredient_PV", new Ingredient());
        }

        public PartialViewResult BlankEditorRowStep()
        {
            return PartialView("Step_PV", new Step());
        }
    }
}