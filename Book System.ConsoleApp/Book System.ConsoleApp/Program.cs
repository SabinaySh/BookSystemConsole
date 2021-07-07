using Book_System.ConsoleApp.Model;
using System;
using System.Text;
using Helper.Lib;

namespace Book_System.ConsoleApp
{
    class Program
    {
        private static  Author[] authors = new Author[0];
        
        private static Book[] books = new Book[0];
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            int selectInt;
            do
            {
                #region Author List
                HelperConsole.ListMenu("Commands For Authors");

                Console.WriteLine("1. Add Author");
                Console.WriteLine("2. Edit Author");
                Console.WriteLine("3. Delete Author");
                Console.WriteLine("4. Select All Authors");
                Console.WriteLine("5. Filter Authors");
                Console.WriteLine("0. Exit");
                #endregion

                #region Book List
                HelperConsole.ListMenu("Commands For Books");

                Console.WriteLine("6. Add Book");
                Console.WriteLine("7. Edit Book");
                Console.WriteLine("8. Delete Book");
                Console.WriteLine("9. Select All Books");
                Console.WriteLine("10. Filter Books");
                #endregion

                #region List Selection
                Console.Write("\nPlease enter your selection: ");
                string select = Console.ReadLine();
                while (!int.TryParse(select, out selectInt))
                {
                    HelperConsole.ConsoleRedColor("\nPlease enter a number");
                    Console.Write("Please enter your selection: ");
                    select = Console.ReadLine();
                }

                #endregion

                #region List switch
                switch (selectInt)
                {
                    case 0:
                        continue;
                    case 1:
                        Console.Clear();
                        ShowAuthorAdd();
                        break;
                    case 2:
                        Console.Clear();
                        ShowEditAuthor();
                        break;
                    case 3:
                        Console.Clear();
                        ShowDeleteAuthor();
                        break;
                    case 4:
                        ShowAllAuthors();
                        break;
                    case 5:
                        Console.Clear();
                        ShowFilterAuthors();
                        break;
                    case 6:
                        Console.Clear();
                        ShowBookAdd();
                        break;
                    case 7:
                        Console.Clear();
                        ShowEditBook();
                        break;
                    case 8:
                        Console.Clear();
                        ShowDeleteBook();
                        break;
                    case 9:
                        ShowAllBooks();
                        break;
                    case 10:
                        Console.Clear();
                        ShowFilterBooks();
                        break;
                    default:
                        HelperConsole.ConsoleRedColor("\nYou made the wrong choice,please choose between 1-10");
                        break;
                }
                #endregion

            } while (selectInt != 0);
        }
        static void ShowAuthorAdd()
        {
            #region Header Add Author
            HelperConsole.ConsoleDarkYellow("Add New Author");
        #endregion

            #region Enter Author Name
        lname:
            string authorName = HelperConsole.ReadText("Author name", 1);

            if (int.TryParse(authorName, out int selectName))
            {
                HelperConsole.ConsoleRedColor("\nPlease enter a letter");
                goto lname;
            }

            if (authorName.Length < 3)
            {
                HelperConsole.ConsoleRedColor("\nThe name must be at least three letters");
                goto lname;
            }
        #endregion

            #region Enter Author Surname
        lSurname:
            string authorSurname = HelperConsole.ReadText("Author surname", 1);
            
            if (int.TryParse(authorSurname, out int selectSurname))
            {
                HelperConsole.ConsoleRedColor("\nPlease enter a letter");
                goto lSurname;
            }
            if (authorSurname.Length < 3)
            {
                HelperConsole.ConsoleRedColor("\nThe surname must be at least three letters");
                goto lSurname;
            }
            #endregion

            #region Add Author Name And Surname
            Array.Resize(ref authors, authors.Length + 1);
            authors[authors.Length - 1] = new Author(authorName,authorSurname);
            #endregion

            #region Footer Add Author
            HelperConsole.ConsoleGreenColor("Added New Author");
            #endregion
        }

        static void ShowEditAuthor()
        {
            #region Header Edit Author
            HelperConsole.ConsoleDarkYellow("Edit Author");
            #endregion

            int authorId = HelperConsole.ReadInt("Author Id");

            #region Check Condition
            int index = Array.FindIndex(authors, a => a.Id == authorId);
            if (index == -1)
            {
                HelperConsole.ConsoleRedColor($"'{authorId}' was not founded");
            } 
            else
            {
                lname:
                string authorName = HelperConsole.ReadText("Author Name", 1);
                if (int.TryParse(authorName, out int selectName))
                {
                    HelperConsole.ConsoleRedColor("\nPlease enter a letter");
                    goto lname;
                }
                lSurname:
                string authorSurname = HelperConsole.ReadText("Author Surname", 1);
                if (int.TryParse(authorSurname, out int selectSurname))
                {
                    HelperConsole.ConsoleRedColor("\nPlease enter a letter");
                    goto lSurname;
                }
                authors[index].Name = authorName;
                authors[index].Surname = authorSurname;
            }
            #endregion

            #region Footer Edit Author
            HelperConsole.ConsoleGreenColor("Edited Author");
            #endregion
        }

        static void ShowDeleteAuthor()
        {
            #region Header Delete Author
            HelperConsole.ConsoleDarkYellow("Delete Author");
            #endregion

            int authorId = HelperConsole.ReadInt("Author Id");

            #region Check Condition
            int index = Array.FindIndex(authors, a => a.Id == authorId);
            if (index == -1)
            {
                HelperConsole.ConsoleRedColor($"'{authorId}' was not founded");
            }
            else
            {
                for (int i = index; i < authors.Length - 1; i++)
                {
                    index = i;
                    authors[index] = authors[index + 1];
                }
                Array.Resize(ref authors, authors.Length - 1);
            }
            #endregion

            #region Footer Delete Author
            HelperConsole.ConsoleGreenColor($"'{authorId}' Deleted Author");
            #endregion
        }

        static void ShowAllAuthors()
        {
            #region Header All Authors
            HelperConsole.ConsoleDarkYellow("All Authors");
            #endregion

            #region Foreach Loop
            foreach (Author author in authors)
            {
                Console.WriteLine(author);
            }
            #endregion
        }

        static void ShowFilterAuthors()
        {
            #region Header Filter Authors
            HelperConsole.ConsoleDarkYellow("Filter Authors");
        #endregion

            #region Check Condition
        label:
            string search = HelperConsole.ReadText("Please filter text", 1);
            if (int.TryParse(search, out int select))
            {
                HelperConsole.ConsoleRedColor("\nPlease enter a letter");
                goto label;
            }
            #endregion

            #region Foreach Loop
            string error = "";
            foreach (Author author in authors)
            {
                if (author.Name.Contains(search) || author.Surname.Contains(search))
                {
                    HelperConsole.ConsoleGreenColor($"{author}");
                }
                error = $"\nYour search '{search}' was not found";
            }
            HelperConsole.ConsoleRedColor(error);


            #endregion
        }

        static void ShowBookAdd()
        {
            #region Header Book
            HelperConsole.ConsoleDarkYellow("Add New Book");
        #endregion

            #region Check Condition
        lname:
            string bookName = HelperConsole.ReadText("Book name", 1);
            if (int.TryParse(bookName, out int selectName))
            {
                HelperConsole.ConsoleRedColor("\nPlease enter a letter");
            }
            if (bookName.Length < 3)
            {
                HelperConsole.ConsoleRedColor("\nThe book name must be at least three letters");
                goto lname;
            }
            #endregion

            #region Add Book
            Array.Resize(ref books, books.Length + 1);
            books[books.Length - 1] = new Book(bookName);
            #endregion

            #region Footer Book
            HelperConsole.ConsoleGreenColor("Added New Author");
            #endregion
        }

        static void ShowEditBook()
        {
            #region Header Edit Book
            HelperConsole.ConsoleDarkYellow("Edit Book");
            #endregion

            #region Check Condition
            int bookId = HelperConsole.ReadInt("Book Id");
            int index = Array.FindIndex(books, a => a.Id == bookId);
            if (index == -1)
            {
                HelperConsole.ConsoleRedColor($"'{bookId}' was not founded");
            }
            else
            {
                lname:
                string bookName = HelperConsole.ReadText("Book Name", 1);
                if (int.TryParse(bookName, out int selectName))
                {
                    HelperConsole.ConsoleRedColor("\nPlease enter a letter");
                    goto lname;
                }
                books[index].Name = bookName;
            }
            #endregion

            #region Footer Edit Book
            HelperConsole.ConsoleGreenColor("Edited Book");
            #endregion
        }

        static void ShowDeleteBook()
        {
            #region Header Delete Book
            HelperConsole.ConsoleDarkYellow("Delete Book");
            #endregion

            #region Check Condition
            int bookId = HelperConsole.ReadInt("Book Id");
            int index = Array.FindIndex(books, a => a.Id == bookId);
            if (index == -1)
            {
                HelperConsole.ConsoleRedColor($"'{bookId}' was not founded");
            }
            else
            {
                for (int i = index; i < books.Length - 1; i++)
                {
                    index = i;
                    books[index] = books[index + 1];
                }
                Array.Resize(ref books, books.Length - 1);
                HelperConsole.ConsoleGreenColor($"'{bookId}'  deleted");
            }
            #endregion
        }

        static void ShowAllBooks()
        {
            #region Header All Books
            HelperConsole.ConsoleDarkYellow("All Books");
            #endregion

            #region Foreach Loop
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            #endregion
        }

        static void ShowFilterBooks()
        {
            #region Header Filter Books
            HelperConsole.ConsoleDarkYellow("Filter Books");
            #endregion

            #region Foreach Loop
            string error = "";
            string search = HelperConsole.ReadText("Please filter text", 1);
            foreach (Book book in books)
            {
                if (book.Name.Contains(search))
                {
                    HelperConsole.ConsoleGreenColor($"{book}");
                    return;
                }
                error = $"\nYour search '{search}' was not found";
            }
            
            HelperConsole.ConsoleRedColor(error);
            #endregion
        }
    }
 }
