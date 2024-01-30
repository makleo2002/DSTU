using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Librarian 
    {
        public Librarian()
        {
            SCards = new HashSet<SCard>();
            TCards = new HashSet<TCard>();
        }
        public Librarian(string FirstName, string LastName,int Id_Lib)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id_Lib = Id_Lib;
        }
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Id_Lib { get; set; }

        public virtual Lib IdLibNavigation { get; set; } = null!;
        public virtual ICollection<SCard> SCards { get; set; }
        public virtual ICollection<TCard> TCards { get; set; }
    }
}
