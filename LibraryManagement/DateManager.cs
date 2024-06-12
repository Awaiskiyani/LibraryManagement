using LibraryManagement.Models;
using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class DateManager
    {
        static Dictionary<string, User> user_dictionary = new Dictionary<string, User>();
        static Dictionary<string, Book> book_dictionary = new Dictionary<string, Book>();
      //  Dictionary<Book, User> userbookAssign_dictionary = new Dictionary<Book, User>();

        public static string loggedUser;
        

        public void Login()
        {
            User user = new User();
            Console.WriteLine("Enter user card Id");
            var userCardId = Console.ReadLine();

            Console.WriteLine("Enter password");
            var userPassword = Console.ReadLine();

            user.LibraryCardID = userCardId;
            user.Password = userPassword;

            // user_dictionary.Add("newUser", user);


            if (user.LibraryCardID == "admin" && user.Password == "admin")
            {
                bool loop = true;
                while (loop)
                {
                    Console.Clear();
                    Console.WriteLine("Library Manangement");
                    Console.WriteLine("1. View Available Books");                 
                    Console.WriteLine("2. Add a New Book (Admin)");
                    Console.WriteLine("3. Add a New User (Admin)");
                    Console.WriteLine("4. Logout");
                    var option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            ViewAvailableBook();
                            break;
                        case "2":
                            AddBook();
                            break;
                        case "3":
                            AddUser();
                            break;
                        case "4":
                            loop = false;

                            break;
                        default:
                            Console.WriteLine("Invalid Input! Please Try again");
                            break;

                    }
                    Console.ReadKey();
                }


            }
            else if (!String.IsNullOrEmpty(userCardId) && !String.IsNullOrEmpty(userPassword))
            {


                if (user_dictionary.ContainsKey(userCardId) && user_dictionary.FirstOrDefault().Value.Password == userPassword)
                {
                    loggedUser = userCardId;
                    bool loop = true;
                    while (loop)
                    {
                        Console.Clear();
                        Console.WriteLine("Library Manangement");
                        Console.WriteLine("1. View Available Books");
                        Console.WriteLine("2. Borrow a Book");
                        Console.WriteLine("3. Return a Book");
                        Console.WriteLine("4. Logout");
                        var option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                ViewAvailableBook();
                                break;
                            case "2":
                                BorrowBook();
                                break;
                            case "3":
                                ReturnBook();
                                break;
                            case "4":
                                loop = false;

                                break;
                            default:
                                Console.WriteLine("Invalid Input! Please Try again");
                                break;

                        }
                        Console.ReadKey();
                    }


                }
                else
                {
                    Console.WriteLine("No Data Found");
                }

            }
            else
            {
                Console.WriteLine("USerID and Password is not found! Plz try again.");
                Console.ReadKey();
            }


        }

        public void AddUser()
        {
            User user = new User();

            //Console.Write("Enter key : ");
            //string key = Console.ReadLine();
            //if (user_dictionary.ContainsKey(key))
            //{
            //    Console.WriteLine("Key already exists!");
            //    return;
            //}

            Console.Write("Enter Library Card ID ");
            user.LibraryCardID = Console.ReadLine();
            Console.WriteLine("Enter User Name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter Password");
            user.Password = Console.ReadLine();
            user.IsAdmin = false;
            if (user_dictionary.ContainsKey(user.LibraryCardID))
            {
                Console.WriteLine(" The user with this Library Cared  is already exists");
            }
            else
            {
                user_dictionary.Add(user.LibraryCardID, user);

                Console.WriteLine("Entry added successfully.");

                foreach (var item in user_dictionary)
                {
                    Console.WriteLine(item.Value.LibraryCardID + " " + item.Value.Name + " " + item.Value.Password);
                }
            }

        }

        public void AddBook()
        {







            Book book = new Book();
            Console.WriteLine("Enter Book ISBN");
            book.ISBN = Console.ReadLine();
            Console.WriteLine("Enter Book Name");
            book.Title = Console.ReadLine();
            Console.WriteLine("Author Name");
            book.Author = Console.ReadLine();
            //Console.WriteLine("IsAvailable? (yes/No)");
            //do
            //{
            //    string isAvailableInput = Console.ReadLine();
            //    if (isAvailableInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || isAvailableInput.Equals("no", StringComparison.OrdinalIgnoreCase))
            //    {
            //        book.IsAvailable = isAvailableInput.Equals("yes", StringComparison.OrdinalIgnoreCase);
            //        break; 
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'. Please try again.");
            //    }
            //} while (true);


            if (book_dictionary.ContainsKey(book.ISBN))
            {
                Console.WriteLine(" The book with this ISBN is already exists");
            }
            else
            {
                book_dictionary.Add(book.ISBN, book);

                foreach (var item in book_dictionary)
                {
                    Console.WriteLine($"{item.Value.ISBN}   {item.Value.Title}  {item.Value.Author}  {item.Value.IsAvailable}");
                }
            }


        }

        public void ViewAvailableBook()
        {
            var availableBooks = book_dictionary.Where(b => b.Value.IsAvailable==true).ToList();
            foreach (var books in availableBooks)
            {
                Console.WriteLine($"{books.Value.ISBN}  {books.Value.Title}  {books.Value.Author} {books.Value.IsAvailable} ");
            }
        }

        public void BorrowBook()
        {
            Console.WriteLine("LoggedUser: " + loggedUser);
            Console.WriteLine("Enter the ISBN Number of the Book that you want to borrow");
            string bookISBN = Console.ReadLine();

            if (book_dictionary.ContainsKey(bookISBN))
            {

               // var canborrow = book_dictionary.Where(b => b.Value.IsAvailable == true);

                //if (book_dictionary[bookISBN].ToUser.LibraryCardID=="None")
                //{

                //}

                var book = book_dictionary[bookISBN];


                if (book.ToUser == null)
                {
                    book.ToUser = new User();
                }


                book.ToUser.LibraryCardID = loggedUser;
                book.IsAvailable = false;

                foreach (var books in book_dictionary)
                {
                   
                    var assignedUser = books.Value.ToUser != null ? books.Value.ToUser.LibraryCardID : "None";

                    Console.WriteLine($"ISBN: {books.Key}, Title: {books.Value.Title}, Assigned User: {assignedUser}");
                }
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public void ReturnBook()
        {
            Console.WriteLine("Enter Book ISBN: ");
            var bookISBN = Console.ReadLine();
            if(book_dictionary.ContainsKey(bookISBN))
            {
                if (book_dictionary[bookISBN].ToUser != null)
                {
                    var returnbook = book_dictionary[bookISBN].ToUser.LibraryCardID == loggedUser;//Any(x=>x.Value.ToUser.LibraryCardID==loggedUser);
                    if (returnbook)
                    {
                        book_dictionary.FirstOrDefault().Value.ToUser.LibraryCardID = "None";
                        book_dictionary[bookISBN].IsAvailable = true;
                    }
                }
                else
                {
                    Console.WriteLine("Book Not found... or Book Borrowed");
                }
                
            }
        }
    }
    }
