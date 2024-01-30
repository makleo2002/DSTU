using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Models
{
    public partial class Lib
    {
        public Lib()
        {
            Librarians = new HashSet<Librarian>();
            SCards = new HashSet<SCard>();
            TCards = new HashSet<TCard>();
            Books = new HashSet<Book>();
        }
        public Lib(string Name)
        {
            this.Name = Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Librarian> Librarians { get; set; }
        public virtual ICollection<SCard> SCards { get; set; }
        public virtual ICollection<TCard> TCards { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
