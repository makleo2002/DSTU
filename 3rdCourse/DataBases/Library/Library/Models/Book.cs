using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Book
    {
        public Book()
        {
            SCards = new HashSet<SCard>();
            TCards = new HashSet<TCard>();
        }
        public Book(string Name, int Pages, int YearPress, int Id_Lib, string Theme, string Category, string Author, string Press, string Comment,int Quantity)
        {
            this.Name = Name;
            this.Pages = Pages;       
            this.YearPress=YearPress;
            this.Id_Lib = Id_Lib;
            this.Theme = Theme;
            this.Category = Category;
            this.Author = Author;
            this.Press=Press;
            this.Comment= Comment;
            this.Quantity=Quantity;
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int Id_Lib { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Press { get; set; }
        public string Theme { get; set; }
        public string? Comment { get; set; }
        public int Quantity { get; set; }
        public virtual Lib IdLibNavigation { get; set; } = null!;
        public virtual ICollection<SCard> SCards { get; set; }
        public virtual ICollection<TCard> TCards { get; set; }
    }
}
