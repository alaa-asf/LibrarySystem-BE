namespace LibrarySystem.Data.DTOs
{
    public class PageableQueryParameters
{
    private readonly static int DEFAULT_MAX_PAGE_SIZE = 1000;
    public int PageNumber { get; set; } = 1;
    private int pageSize = 10;

    public int PageSize
    {
        get => pageSize;
        set => pageSize = value <= DEFAULT_MAX_PAGE_SIZE ? value : DEFAULT_MAX_PAGE_SIZE;
    }

}
}
