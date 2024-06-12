using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibraryManagement.Repo
{
    internal class Services:IServices
    {
        private readonly DateManager _dateManager;

        public Services(DateManager data)
        {
           // _dateManager = data;
            _dateManager=new DateManager();
        }

        public Services()
        {

        }

        DateManager db = new DateManager();


        public void AddUSer()
        {
            //_dateManager.AddUser();
            db.AddUser();
        }

        public void AddBook()
        {
            // _dateManager.AddBook();
            db.AddBook();
        }

       public void ViewAvailableBook()
        {
            // _dateManager.ViewAvailableBook();
            db.ViewAvailableBook();
        }

        public void BorrowBook()
        {
            //_dateManager.BorrowBook();
            db.BorrowBook();
        }

        public void ReturnBook()
        {
           // _dateManager.ReturnBook();
           db.ReturnBook();
        }

        public void Login()
        {
             //_dateManager.Login();
            db.Login();
        }

    }
}
