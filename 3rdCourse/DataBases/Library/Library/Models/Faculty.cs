﻿using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Groups = new HashSet<Group>();
        }
        public Faculty(string Name)
        {
            this.Name = Name;
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Group> Groups { get; set; }
    }
}
