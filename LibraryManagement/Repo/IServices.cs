using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repo
{
    internal interface IServices
    {
        void AddUSer();
        void AddBook();
        void ViewAvailableBook();
        void BorrowBook();
        void ReturnBook();
        void Login();
    }
}
