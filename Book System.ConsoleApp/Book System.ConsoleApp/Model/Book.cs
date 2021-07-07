using System;
using System.Collections.Generic;
using System.Text;

namespace Book_System.ConsoleApp.Model
{
    class Book
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.Id = counter;
        }
        public Book(string bookName)
            : this()
        {
            this.Name = bookName;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}.{Name}";
        }
    }
}
