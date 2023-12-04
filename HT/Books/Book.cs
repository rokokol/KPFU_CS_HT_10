using System;

namespace Books
{
    public struct Book
    {
        public string name;
        public string publishHouse;
        public string author;

        public Book(string name, string publishHouse, string author)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.publishHouse = publishHouse ?? throw new ArgumentNullException(nameof(publishHouse));
            this.author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public override string ToString()
        {
            return $": {name}, {publishHouse}, {author} :";
        }

        public bool Equals(Book other)
        {
            return name == other.name && publishHouse == other.publishHouse && author == other.author;
        }

        public override bool Equals(object obj)
        {
            return obj is Book other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (publishHouse != null ? publishHouse.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (author != null ? author.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}