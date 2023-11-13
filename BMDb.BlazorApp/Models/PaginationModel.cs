namespace BMDb.BlazorApp.Models;

public class PaginationModel<TModel>
{
    public IEnumerable<TModel> Items { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get; }

    public PaginationModel(IEnumerable<TModel> items, int page, int pageSize, int count)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalPages = Convert.ToInt32(Math.Ceiling((float)count / pageSize));
    }

    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}