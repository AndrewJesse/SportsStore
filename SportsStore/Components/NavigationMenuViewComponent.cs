using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo) 
        { 
            repository = repo; 
        }
        public IViewComponentResult Invoke() { 
            // Sets the Viewbag.SelectedCategory to hold the the 'category' from the RouteData
            ViewBag.SelectedCategory = RouteData?.Values["category"]; 

            return View(repository.Products .Select(x => x.Category) .Distinct() .OrderBy(x => x));
        }
    }
}
