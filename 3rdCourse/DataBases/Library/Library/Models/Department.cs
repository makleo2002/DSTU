using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Department 
    {
        public Department()
        {
            Teachers = new HashSet<Teacher>();
        }
        public Department(string Name)
        {
            this.Name = Name;
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
