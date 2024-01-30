using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }
        public Group(string Name, int Id_Faculty)
        {
            this.Name = Name;
            this.Id_Faculty = Id_Faculty;
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Id_Faculty { get; set; }
        public virtual Faculty IdFacultyNavigation { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
