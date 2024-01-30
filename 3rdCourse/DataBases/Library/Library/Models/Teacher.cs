using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Teacher 
    {
        public Teacher()
        {
            TCards = new HashSet<TCard>();
        }

        public Teacher(string FirstName, string LastName,int id_Dep)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id_Dep = Id_Dep; 
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Id_Dep { get; set; }

        public virtual Department IdDepNavigation { get; set; } = null!;
        public virtual ICollection<TCard> TCards { get; set; }
    }
}
