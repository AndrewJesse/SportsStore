namespace SportsStore.Models.ViewModels
{
    // This class defines a ViewModel for a list of products along with pagination information.
    public class ProductsListViewModel
    {
        // A collection of Product objects representing the products to display.
        // Default value is an empty enumerable.
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

        // An instance of PagingInfo containing pagination details for the products list.
        // Default value is a new PagingInfo object.
        public PagingInfo PagingInfo { get; set; } = new();
    }

}
