using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class TCard 
    {
        public TCard( )
        {
           
        }
        public TCard(int Id_Teacher, int Id_Book, DateTime DateIn, DateTime DateOut, int Id_Lib, int Id_Librarian)
        {
            this.Id_Teacher = Id_Teacher;
            this.Id_Book = Id_Book;
            this.Id_Lib = Id_Lib;
            this.Id_Librarian = Id_Librarian;
            this.DateOut = DateOut;
            this.DateIn = DateIn;

        }
        public int Id { get; set; }
        public int Id_Teacher { get; set; }
        public int Id_Book { get; set; }
        public int Id_Lib { get; set; }
        public int Id_Librarian { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
  
        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual Lib IdLibNavigation { get; set; } = null!;
        public virtual Librarian IdLibrarianNavigation { get; set; } = null!;
        public virtual Teacher IdTeacherNavigation { get; set; } = null!;
    }
}
