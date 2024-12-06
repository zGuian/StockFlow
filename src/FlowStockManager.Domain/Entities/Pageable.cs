namespace FlowStockManager.Domain.Entities
{
    public class Pageable<T> where T : class
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Data { get; set; } = null!;

        public Pageable(IEnumerable<T> data, int totalItems, int itemsPerPage, int currentPage)
        {
            Data = data; 
            TotalItems = totalItems; 
            ItemsPerPage = itemsPerPage; 
            CurrentPage = currentPage; 
            TotalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
        }
    }
}
