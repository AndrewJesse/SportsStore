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
/**Between Default.cshtml and NavigationMenuViewComponent which inherits from the ViewComponent class. The Invoke() method is part of the ViewComponent class and is used to perform the main task of the view component. In this case, the Invoke() method sets the ViewBag.SelectedCategory and returns the list of distinct categories in the repository.

The Default.cshtml file is a Razor view file that is used to render the output of the NavigationMenuViewComponent. This view file is associated with the view component by convention, as it's named "Default.cshtml" and placed in the corresponding "Components/NavigationMenu" folder in the "Views" directory of the application.

The connection between the two classes is established by the ASP.NET Core framework itself. When you use the ViewComponent in a Razor view (or layout), you usually call it using @await Component.InvokeAsync("NavigationMenu"). The framework then searches for a class named "NavigationMenuViewComponent" and calls its Invoke() (or InvokeAsync() if it exists) method.

In your code snippet, the Razor view file uses ViewBag.SelectedCategory to determine if the current category is selected. It does this by comparing category with ViewBag.SelectedCategory. If they are the same, the button will have a "btn-primary" class; otherwise, it will have a "btn-outline-secondary" class. The Invoke() method in the NavigationMenuViewComponent sets ViewBag.SelectedCategory*/