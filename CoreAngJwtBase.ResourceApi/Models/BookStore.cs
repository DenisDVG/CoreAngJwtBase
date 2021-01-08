using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngJwtBase.ResourceApi.Models
{
    public class BookStore
    {
        public List<Book> Books => new List<Book>
        {
            new Book { Id = 1, Author = "J. K. RowLing", Title= "H Potter", Price = 10.45M},
            new Book { Id = 2, Author = "Dkms", Title= "H", Price = 8.43M},
            new Book { Id = 3, Author = "Ling", Title= "Potter", Price = 7.22M},
            new Book { Id = 4, Author = "Row", Title= "Hotter", Price = 11.11M}
        };

        public Dictionary<Guid, int[]> Order => new Dictionary<Guid, int[]>
        {
            {Guid.Parse("dbe1680f-ac76-48ad-9be3-b800c86f3fa6"), new int[] { 1, 3} },
            {Guid.Parse("65cd157b-3e78-4a97-9298-2f89d86181c4"), new int[] { 2, 3, 4} }
        };
    }
}
