using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCelulares.Controllers.DTO
{
    public class Paginacion<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public Paginacion(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static Paginacion<T> CreateAsync(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new Paginacion<T>(items, count, pageNumber, pageSize);
        }
    }
}
