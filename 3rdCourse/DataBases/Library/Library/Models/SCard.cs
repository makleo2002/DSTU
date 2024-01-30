using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class SCard 
    {
        
        public int Id { get; set; }
        public int Id_Student { get; set; }
        public int Id_Book { get; set; }
        public int Id_Lib { get; set; }
        public int Id_Librarian { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        
        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual Librarian IdLibrarianNavigation { get; set; } = null!;
        public virtual Lib IdLibNavigation { get; set; } = null!;
        public virtual Student IdStudentNavigation { get; set; } = null!;
    }
}
