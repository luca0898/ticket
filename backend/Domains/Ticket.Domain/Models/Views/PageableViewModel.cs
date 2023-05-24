namespace Ticket.Domain.Models.Views;

public class PageableViewModel<TEntity>
{
    public IEnumerable<TEntity> Items { get; set; } = Enumerable.Empty<TEntity>();
    public int Page { get; set; }
    public int Count { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }

    public PageableViewModel(IEnumerable<TEntity> items, int page, int count, int totalCount, int totalPages)
    {
        Items = items;
        Page = page;
        Count = count;
        TotalCount = totalCount;
        TotalPages = totalPages;
    }
}
