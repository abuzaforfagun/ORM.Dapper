using System;

namespace ORM.Dapper.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
    }
}