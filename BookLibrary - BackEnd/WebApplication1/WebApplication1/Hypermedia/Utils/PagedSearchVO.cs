using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Hypermedia.Abstract;

namespace WebApplication1.Hypermedia.Utils
{
  public class PagedSearchVO<T> where T : ISupportsHyperMedia
  {
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalResults { get; set; }
    public string SortedFields { get; set; }
    public string SortedDirections { get; set; }
    public Dictionary<string, Object> Filters { get; set; }
    public List<T> List { get; set; }

    public PagedSearchVO()
    {
    }

    public PagedSearchVO(int currentPage, int pageSize, string sortedFields, string sortedDirections)
    {
      CurrentPage = currentPage;
      PageSize = pageSize;
      SortedFields = sortedFields;
      SortedDirections = sortedDirections;
    }

    public PagedSearchVO(int currentPage, int pageSize, string sortedFields, string sortedDirections, Dictionary<string, object> filters)
    {
      CurrentPage = currentPage;
      PageSize = pageSize;
      SortedFields = sortedFields;
      SortedDirections = sortedDirections;
      Filters = filters;
    }

    public PagedSearchVO(int currentPage, string sortedFields, string sortedDirections) :
      this(currentPage, 10, sortedFields, sortedDirections){}

    public int GetCurrentPage()
    {
      return CurrentPage == 0 ? 2 : CurrentPage;
    }

    public int GetPageSize()
    {
      return PageSize == 0 ? 10 : PageSize;
    }
  }
}
