using System;

namespace HT
{
    public class Human
    {
        public EventHandler likedEvents;
        public string Name;

        public Human(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}