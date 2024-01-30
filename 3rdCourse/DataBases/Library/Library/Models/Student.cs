using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Student 
    {
        public Student()
        {
            SCards = new HashSet<SCard>();
        }
        public Student(string FirstName, string LastName, int Id_Group, int Term)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id_Group = Id_Group;
            this.Term = Term;
        }
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Id_Group { get; set; }
        public int Term { get; set; }

        public virtual Group IdGroupNavigation { get; set; } = null!;
        public virtual ICollection<SCard> SCards { get; set; }
    }
}
