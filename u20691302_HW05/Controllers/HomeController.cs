using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20691302_HW05.Data;
using u20691302_HW05.Models;

namespace u20691302_HW05.Controllers
{
    public class HomeController : Controller
    {
        string studentID = "", bookID = "";

        public ActionResult Home()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        //Send database table to  book view
        public ActionResult Books()
        {
            List<booksVM> books = new List<booksVM>();

            DataService dataService = new DataService();

            books = dataService.FetchAllBooks();

            return View(books);
        }

        //Send database table to borrow view
        public ActionResult Borrows(string bookId)
        {
            List<borrowsVM> borrows = new List<borrowsVM>();

            DataService dataService = new DataService();

            borrows = dataService.FetchAllBorrows(bookId);
            bookID = bookId;

            return View(borrows);
        }

        //Send database table to student view
        public ActionResult Students()
        {
            List<students> students = new List<students>();

            DataService dataService = new DataService();

            students = dataService.FetchAllStudents();

            return View(students);
        }



        //Send queried databases to book view
        public ActionResult SearchBooks(string bookName, string typeId, string authorId)
        {
            List<booksVM> books = new List<booksVM>();

            DataService dataService = new DataService();

            if (bookName != "" && typeId == ""  && authorId == "")
            {
                books = dataService.FetchBooksByName(bookName);
            }
            else if (bookName == "" && typeId != "" && authorId == "")
            {
                books = dataService.FetchBooksByType(typeId);
            }
            else if (bookName == "" && typeId == "" && authorId != "")
            {
                books = dataService.FetchBooksByAuthor(authorId);
            }
            else if (bookName != "" && typeId != "" && authorId == "")
            {
                books = dataService.FetchBooksByBookAndType(bookName, typeId);
            }
            else if (bookName != "" && typeId == "" && authorId != "")
            {
                books = dataService.FetchBooksByBookAndAuthor(bookName, authorId);
            }
            else if (bookName == "" && typeId != "" && authorId != "")
            {
                books = dataService.FetchBooksByTypeAndAuthor(typeId, authorId);
            }
            else if (bookName != "" && typeId != "" && authorId != "")
            {
                books = dataService.FetchBooksByAll(bookName, typeId, authorId);
            }

            return View("Books", books);
        }

        //Send queried databases to book view
        public ActionResult SearchStudents(string studentName, string Class)
        {
            List<students> students = new List<students>();

            DataService dataService = new DataService();

            if (studentName != "" && Class == "")
            {
                students = dataService.FetchStudentsByName(studentName);
            }
            else if (studentName == "" && Class != "")
            {
                students = dataService.FetchStudentsByClass(Class);
            }
            else if (studentName != "" && Class != "")
            {
                students = dataService.FetchStudentsByAll(studentName, Class);
            }

            return View("Students", students);
        }



        //Create new borrow
        public ActionResult BorrowBook(string studentId)
        {
            studentID = studentId;
            DataService dataService = new DataService();

            //dataService.BorrowBook(bookID, studentID);

            return RedirectToAction("Books", "Home");
        }
    }
}