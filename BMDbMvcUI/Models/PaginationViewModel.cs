namespace BMDbMvcUI.Models;

public class PaginationViewModel<TModel>
{
    public IEnumerable<TModel> Items { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get; }

    public PaginationViewModel(IEnumerable<TModel> items, int page, int pageSize, int count)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
    }

    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}