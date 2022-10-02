using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using u20691302_HW05.Models;

namespace u20691302_HW05.Data
{
    public class DataService
    {
        //Connection string
        private string connectionString = "Data source=LAPTOP-E5ULLR78\\SQLEXPRESS;" +
                                          "Initial Catalog=Library;Integrated Security=true";



        //Fetch and read database into books table
        public List<booksVM> FetchAllBooks()
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM books";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public books getBooksById(int bookId)
        {
            books books = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM books WHERE bookId = " + bookId;
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        books = new books
                        {
                            bookId = Convert.ToInt32(reader["bookId"]),
                            name = Convert.ToString(reader["name"]),
                            pagecount = Convert.ToInt32(reader["pagecount"]),
                            point = Convert.ToInt32(reader["point"]),
                            authorId = Convert.ToInt32(reader["authorId"]),
                            typeId = Convert.ToInt32(reader["typeId"])
                        };
                    }
                }
            }
            return books;
        }

        public authors getAuthorById(int authorId)
        {
            authors authors = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM authors WHERE authorId = " + authorId;
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authors = new authors
                        {
                            authorId = Convert.ToInt32(reader["authorId"]),
                            name = Convert.ToString(reader["name"]),
                            surname = Convert.ToString(reader["surname"])
                        };
                    }
                }
            }
            return authors;
        }

        public types getTypeById(int typeId)
        {
            types types = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM types WHERE typeId = " + typeId;
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        types = new types
                        {
                            typeId = Convert.ToInt32(reader["typeId"]),
                            name = Convert.ToString(reader["name"]),
                        };
                    }
                }
            }
            return types;
        }




        //Fetch and read database into borrows table
        public List<borrowsVM> FetchAllBorrows(string bookID)
        {
            List<borrowsVM> returnList = new List<borrowsVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM borrows WHERE bookId = " + bookID + " ORDER BY borrowId Desc";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int borrowId = Convert.ToInt32(reader["borrowId"]);
                        int studentId = Convert.ToInt32(reader["studentId"]);

                        //Create a new book object and add it to the list to return.
                        borrowsVM books = new borrowsVM
                        {
                            book = getBooksById(Convert.ToInt32(bookID)),
                            borrow = getBorrowsById(borrowId),
                            student = getStudentsById(studentId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public borrows getBorrowsById(int borrowId)
        {
            borrows borrows = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM borrows WHERE borrowId = " + borrowId;
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        borrows = new borrows
                        {
                            borrowId = Convert.ToInt32(reader["borrowId"]),
                            takenDate = Convert.ToDateTime(reader["takenDate"]),
                            broughtDate = Convert.ToDateTime(reader["broughtDate"]),
                            studentId = Convert.ToInt32(reader["studentId"]),
                            bookId = Convert.ToInt32(reader["bookId"]),
                        };
                    }
                }
            }
            return borrows;
        }

        public students getStudentsById(int studentId)
        {
            students students = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM students WHERE studentId = " + studentId;
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        students = new students
                        {
                            studentId = Convert.ToInt32(reader["studentId"]),
                            name = Convert.ToString(reader["name"]),
                            surname = Convert.ToString(reader["surname"]),
                            birthdate = Convert.ToDateTime(reader["birthdate"]),
                            gender = Convert.ToString(reader["gender"]),
                            Class = Convert.ToString(reader["class"]),
                            point = Convert.ToInt32(reader["point"])
                        };
                    }
                }
            }
            return students;
        }



        //Fetch and read database into students table
        public List<students> FetchAllStudents()
        {
            List<students> returnList = new List<students>();

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM students";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then we can loop through the list and populate table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create new marine animal object and add it to the list to return.
                        students students = new students();

                        students.studentId = Convert.ToInt32(reader["studentId"]);
                        students.name = Convert.ToString(reader["name"]);
                        students.surname = Convert.ToString(reader["surname"]);
                        students.birthdate = Convert.ToDateTime(reader["birthdate"]);
                        students.gender = Convert.ToString(reader["gender"]);
                        students.Class = Convert.ToString(reader["class"]);
                        students.point = Convert.ToInt32(reader["point"]);

                        returnList.Add(students);
                    }
                }
            }
            return returnList;
        }




        //Fetch and read database into books table by search query
        public List<booksVM> FetchBooksByName(string bookName)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM books WHERE name LIKE '%" + bookName + "%'";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public List<booksVM> FetchBooksByType(string typeID)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (Convert.ToInt32(typeID) == 10)
                {
                    sqlQuery = "SELECT * FROM books WHERE typeId = " + typeID + " OR typeId = " + 12;
                }
                else if (Convert.ToInt32(typeID) == 12)
                {
                    sqlQuery = "SELECT * FROM books WHERE typeId = " + 10 + " OR typeId = " + typeID;
                }
                else
                {
                    sqlQuery = "SELECT * FROM books WHERE typeId = " + typeID;
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public List<booksVM> FetchBooksByAuthor(string authorID)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM books WHERE authorId = " + authorID;

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public List<booksVM> FetchBooksByBookAndType(string bookName, string typeID)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (Convert.ToInt32(typeID) == 10)
                {
                    sqlQuery = "SELECT * FROM books WHERE (typeId = " + typeID + " OR typeId = " + 12 +
                        ") AND name LIKE '%" + bookName + "%'";
                }
                else if (Convert.ToInt32(typeID) == 12)
                {
                    sqlQuery = "SELECT * FROM books WHERE (typeId = " + 10 + " OR typeId = " + typeID +
                        ") AND name LIKE '%" + bookName + "%'";
                }
                else
                {
                    sqlQuery = "SELECT * FROM books WHERE typeId = " + typeID + " AND name LIKE '%" + bookName + "%'";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public List<booksVM> FetchBooksByBookAndAuthor(string bookName, string authorID)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM books WHERE name LIKE '%" + bookName + "%' AND authorId = " + authorID;
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public List<booksVM> FetchBooksByTypeAndAuthor(string typeID, string authorID)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (Convert.ToInt32(typeID) == 10)
                {
                    sqlQuery = "SELECT * FROM books WHERE (typeId = " + typeID + " OR typeId = " + 12 +
                        ") AND authorId = " + authorID;
                }
                else if (Convert.ToInt32(typeID) == 12)
                {
                    sqlQuery = "SELECT * FROM books WHERE (typeId = " + 10 + " OR typeId = " + typeID +
                        ") AND authorId = " + authorID;
                }
                else
                {
                    sqlQuery = "SELECT * FROM books WHERE typeId = " + typeID + " AND authorId = " + authorID;
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }

        public List<booksVM> FetchBooksByAll(string bookName, string typeID, string authorID)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (Convert.ToInt32(typeID) == 10)
                {
                    sqlQuery = "SELECT * FROM books WHERE name LIKE '%" + bookName + "%' AND (typeId = " +
                        typeID + " OR typeId = " + 12 + ") AND authorId = " + authorID;
                }
                else if (Convert.ToInt32(typeID) == 12)
                {
                    sqlQuery = "SELECT * FROM books WHERE name LIKE '%" + bookName + "%' AND (typeId = " +
                        10 + " OR typeId = " + typeID + ") AND authorId = " + authorID;
                }
                else
                {
                    sqlQuery = "SELECT * FROM books WHERE name LIKE '%" + bookName + "%' AND typeId = " +
                        typeID + " AND authorId = " + authorID;
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through the list and populates table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        //Create a new book object and add it to the list to return.
                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId)
                        };
                        returnList.Add(books);
                    }
                }
                return returnList;
            }
        }


        //Fetch and read database into students table by search query
        public List<students> FetchStudentsByName(string studentName)
        {
            List<students> returnList = new List<students>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM students WHERE name LIKE '%" + studentName + "%'";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then we can loop through the list and populate table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create new student object and add it to the list to return.
                        students students = new students();

                        students.studentId = Convert.ToInt32(reader["studentId"]);
                        students.name = Convert.ToString(reader["name"]);
                        students.surname = Convert.ToString(reader["surname"]);
                        students.birthdate = Convert.ToDateTime(reader["birthdate"]);
                        students.gender = Convert.ToString(reader["gender"]);
                        students.Class = Convert.ToString(reader["class"]);
                        students.point = Convert.ToInt32(reader["point"]);

                        returnList.Add(students);
                    }
                }
            }
            return returnList;
        }

        public List<students> FetchStudentsByClass(string Class)
        {
            List<students> returnList = new List<students>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM students WHERE class = '" + Class + "'";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then we can loop through the list and populate table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create new student object and add it to the list to return.
                        students students = new students();

                        students.studentId = Convert.ToInt32(reader["studentId"]);
                        students.name = Convert.ToString(reader["name"]);
                        students.surname = Convert.ToString(reader["surname"]);
                        students.birthdate = Convert.ToDateTime(reader["birthdate"]);
                        students.gender = Convert.ToString(reader["gender"]);
                        students.Class = Convert.ToString(reader["class"]);
                        students.point = Convert.ToInt32(reader["point"]);

                        returnList.Add(students);
                    }
                }
            }
            return returnList;
        }

        public List<students> FetchStudentsByAll(string studentName, string Class)
        {
            List<students> returnList = new List<students>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM students WHERE name LIKE '%" + studentName + "%' AND class = '" + Class + "'";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then we can loop through the list and populate table
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create new student object and add it to the list to return.
                        students students = new students();

                        students.studentId = Convert.ToInt32(reader["studentId"]);
                        students.name = Convert.ToString(reader["name"]);
                        students.surname = Convert.ToString(reader["surname"]);
                        students.birthdate = Convert.ToDateTime(reader["birthdate"]);
                        students.gender = Convert.ToString(reader["gender"]);
                        students.Class = Convert.ToString(reader["class"]);
                        students.point = Convert.ToInt32(reader["point"]);

                        returnList.Add(students);
                    }
                }
            }
            return returnList;
        }



        //Method to insert new borrow

        //public void BorrowBook(string bookID, string studentID)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sqlQuery = "INSERT INTO borrows (studentId, bookId, takenDate, broughtDate) VALUES ( " +
        //            studentID + ", "  + bookID + ", CAST(N'" + DateTime.Now + "' AS DateTime), CAST(N'" + DBNull.Value + "' AS DateTime))";

        //        SqlCommand command = new SqlCommand(sqlQuery, connection);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}



        //Method to return  borrow

        //public void ReturnBook(int bookID, int studentID)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sqlQuery = "";

        //        SqlCommand command = new SqlCommand(sqlQuery, connection);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}