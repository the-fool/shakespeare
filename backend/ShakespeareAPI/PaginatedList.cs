using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShakespeareAPI
{
  public class PaginatedList<T> 
  {
    public int TotalCount { get; private set; }
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages { get; private set; }
    public List<T> Items {get; set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
      TotalCount = count;
      PageIndex = pageIndex;
      PageSize = pageSize;
      TotalPages = (int)Math.Ceiling(count / (double)pageSize);

      Items = items;
    }

    public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
    {
      var count = source.Count();
      var items = source.Skip(
          (pageIndex - 1) * pageSize)
          .Take(pageSize).ToList();
      return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
  }
}