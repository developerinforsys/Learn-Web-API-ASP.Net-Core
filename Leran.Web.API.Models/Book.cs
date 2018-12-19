using System;

namespace Leran.Web.API.Models
{
    public class Book
    {
        public string Author { get; set; }
        public int Published { get; set; }
        public string[] Genres { get; set; }
        public string Description { get; set;  }
        public string Tittle { get; set; }
        public int Id { get; set; }
    }
}
