using System;
using System.Collections.Generic;
using System.Text;

namespace Book_System.ConsoleApp.Model
{
   public class Author
    {
        static int counter = 0;
        public Author()
        {
            counter++;
            this.Id = counter;
        }
        public Author(string authorName)
            :this()
        {
            this.Name = authorName;
        }
        public Author(string authorName, string authorSurname)
            :this(authorName)
        {
            this.Name = authorName;
            this.Surname = authorSurname;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} {Surname}";
        }
    }
}
