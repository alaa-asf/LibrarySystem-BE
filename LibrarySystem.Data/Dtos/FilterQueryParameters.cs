using LibrarySystem.Data.Models.core;

namespace LibrarySystem.Data.DTOs
{
    public class FilterQueryParameters
{
    public List<SpecsFilter> Filters { get; set; } = new List<SpecsFilter>();
    public List<ExtensionOrderAttribute> OrderBy { get; set; }
    public PageableQueryParameters PageableQuery { get; set; }

}
}
