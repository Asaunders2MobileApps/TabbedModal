using System;

namespace try2.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}