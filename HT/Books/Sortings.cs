using System;

namespace Books
{
    public static class Sortings
    {
        public delegate int Compare(Book a, Book b);

        public static int AuthorSort(Book a, Book b)
        {
            return String.Compare(a.author, b.author, StringComparison.Ordinal);
        }
        
        public static int NameSort(Book a, Book b)
        {
            return String.Compare(a.name, b.name, StringComparison.Ordinal);
        }
        
        public static int PublishHouseSort(Book a, Book b)
        {
            return String.Compare(a.publishHouse, b.publishHouse, StringComparison.Ordinal);
        }
    }
}