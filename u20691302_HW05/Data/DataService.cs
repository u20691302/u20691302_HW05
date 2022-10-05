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

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
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



        //Fetch and read database into books table by search queries
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

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
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

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
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

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }
        public List<booksVM> FetchBooksByNameAndType(string bookName, string typeID)
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

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
                        };
                        returnList.Add(books);
                    }
                }
            }
            return returnList;
        }
        public List<booksVM> FetchBooksByNameAndAuthor(string bookName, string authorID)
        {
            List<booksVM> returnList = new List<booksVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM books WHERE name LIKE '%" + bookName + "%' AND authorId = " + authorID;
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
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

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
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

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int bookId = Convert.ToInt32(reader["bookId"]);
                        int authorId = Convert.ToInt32(reader["authorId"]);
                        int typeId = Convert.ToInt32(reader["typeId"]);

                        booksVM books = new booksVM
                        {
                            book = getBooksById(bookId),
                            author = getAuthorById(authorId),
                            type = getTypeById(typeId),
                            borrow = FetchAllBorrows(bookId)
                        };
                        returnList.Add(books);
                    }
                }
                return returnList;
            }
        }



        //Fetch and read database into borrows table
        public List<borrowsVM> FetchAllBorrows(int bookID)
        {
            List<borrowsVM> returnList = new List<borrowsVM>();

            //Access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM borrows WHERE bookId = " + bookID + " ORDER BY borrowId Desc";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Checks if the reader has rows then loops through
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int borrowId = Convert.ToInt32(reader["borrowId"]);
                        int studentId = Convert.ToInt32(reader["studentId"]);

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

                object returnVal = null;
                object broughtDateCheck = null;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        broughtDateCheck = reader["broughtDate"];
                        if (broughtDateCheck == DBNull.Value)
                        {
                            returnVal = null;
                        }
                        else
                        {
                            returnVal = broughtDateCheck;
                        }
                        borrows = new borrows
                        {
                            
                            borrowId = Convert.ToInt32(reader["borrowId"]),
                            takenDate = Convert.ToDateTime(reader["takenDate"]),
                            broughtDate = Convert.ToDateTime(returnVal),
                            studentId = Convert.ToInt32(reader["studentId"]),
                            bookId = Convert.ToInt32(reader["bookId"])
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
        public List<StudentsVM> FetchAllStudents()
        {
            List<StudentsVM> returnList = new List<StudentsVM>();

            //Access database
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlConnection connection2 = new SqlConnection(connectionString);
            
                string sqlQuery1 = "SELECT * FROM students";
                string sqlQuery2 = "SELECT * FROM books";

                SqlCommand command1 = new SqlCommand(sqlQuery1, connection1);
                SqlCommand command2 = new SqlCommand(sqlQuery2, connection2);

                connection1.Open();
                SqlDataReader reader1 = command1.ExecuteReader();
      
                connection2.Open();
                SqlDataReader reader2 = command2.ExecuteReader();

                //Checks if the reader has rows then loops through
                if (reader1.HasRows && reader2.HasRows)
                {
                    while (reader1.Read() && reader2.Read())
                    {
                        int studentId = Convert.ToInt32(reader1["studentId"]);
                        int bookId = Convert.ToInt32(reader2["bookId"]);

                        StudentsVM books = new StudentsVM
                        {
                            student = getStudentsById(studentId),
                            borrow = FetchAllBorrows(bookId)
                        };
                        returnList.Add(books);
                    }
                }
            return returnList;
        }



        //Fetch and read database into students table by search queries
        public List<StudentsVM> FetchStudentsByName(string studentName)
        {
            List<StudentsVM> returnList = new List<StudentsVM>();

            //Access database
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlConnection connection2 = new SqlConnection(connectionString);

            string sqlQuery1 = "SELECT * FROM students WHERE name LIKE '%" + studentName + "%'";
            string sqlQuery2 = "SELECT * FROM books";

            SqlCommand command1 = new SqlCommand(sqlQuery1, connection1);
            SqlCommand command2 = new SqlCommand(sqlQuery2, connection2);

            connection1.Open();
            SqlDataReader reader1 = command1.ExecuteReader();

            connection2.Open();
            SqlDataReader reader2 = command2.ExecuteReader();

            //Checks if the reader has rows then loops through
            if (reader1.HasRows && reader2.HasRows)
            {
                while (reader1.Read() && reader2.Read())
                {
                    int studentId = Convert.ToInt32(reader1["studentId"]);
                    int bookId = Convert.ToInt32(reader2["bookId"]);

                    StudentsVM books = new StudentsVM
                    {
                        student = getStudentsById(studentId),
                        borrow = FetchAllBorrows(bookId)
                    };
                    returnList.Add(books);
                }
            }
            return returnList;

            //List<StudentsVM> returnList = new List<StudentsVM>();

            ////Access database
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    string sqlQuery = "SELECT * FROM students WHERE name LIKE '%" + studentName + "%'";
            //    SqlCommand command = new SqlCommand(sqlQuery, connection);

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    //Checks if the reader has rows then we can loop through the list and populate table
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            //create new student object and add it to the list to return.
            //            StudentsVM students = new StudentsVM();

            //            students.studentId = Convert.ToInt32(reader["studentId"]);
            //            students.name = Convert.ToString(reader["name"]);
            //            students.surname = Convert.ToString(reader["surname"]);
            //            students.birthdate = Convert.ToDateTime(reader["birthdate"]);
            //            students.gender = Convert.ToString(reader["gender"]);
            //            students.Class = Convert.ToString(reader["class"]);
            //            students.point = Convert.ToInt32(reader["point"]);

            //            returnList.Add(students);
            //        }
            //    }
            //}
            //return returnList;

        }
        public List<StudentsVM> FetchStudentsByClass(string Class)
        {
            List<StudentsVM> returnList = new List<StudentsVM>();

            //Access database
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlConnection connection2 = new SqlConnection(connectionString);

            string sqlQuery1 = "SELECT * FROM students WHERE class = '" + Class + "'";
            string sqlQuery2 = "SELECT * FROM books";

            SqlCommand command1 = new SqlCommand(sqlQuery1, connection1);
            SqlCommand command2 = new SqlCommand(sqlQuery2, connection2);

            connection1.Open();
            SqlDataReader reader1 = command1.ExecuteReader();

            connection2.Open();
            SqlDataReader reader2 = command2.ExecuteReader();

            //Checks if the reader has rows then loops through
            if (reader1.HasRows && reader2.HasRows)
            {
                while (reader1.Read() && reader2.Read())
                {
                    int studentId = Convert.ToInt32(reader1["studentId"]);
                    int bookId = Convert.ToInt32(reader2["bookId"]);

                    StudentsVM books = new StudentsVM
                    {
                        student = getStudentsById(studentId),
                        borrow = FetchAllBorrows(bookId)
                    };
                    returnList.Add(books);
                }
            }
            return returnList;
        }
        public List<StudentsVM> FetchStudentsByAll(string studentName, string Class)
        {
            List<StudentsVM> returnList = new List<StudentsVM>();

            //Access database
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlConnection connection2 = new SqlConnection(connectionString);

            string sqlQuery1 = "SELECT * FROM students WHERE name LIKE '%" + studentName + "%' AND class = '" + Class + "'";
            string sqlQuery2 = "SELECT * FROM books";

            SqlCommand command1 = new SqlCommand(sqlQuery1, connection1);
            SqlCommand command2 = new SqlCommand(sqlQuery2, connection2);

            connection1.Open();
            SqlDataReader reader1 = command1.ExecuteReader();

            connection2.Open();
            SqlDataReader reader2 = command2.ExecuteReader();

            //Checks if the reader has rows then loops through
            if (reader1.HasRows && reader2.HasRows)
            {
                while (reader1.Read() && reader2.Read())
                {
                    int studentId = Convert.ToInt32(reader1["studentId"]);
                    int bookId = Convert.ToInt32(reader2["bookId"]);

                    StudentsVM books = new StudentsVM
                    {
                        student = getStudentsById(studentId),
                        borrow = FetchAllBorrows(bookId)
                    };
                    returnList.Add(books);
                }
            }
            return returnList;
        }


        
        //Method to insert new borrow
        public void BorrowBook(int bookID, int studentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "INSERT INTO dbo.borrows Values(@studentId, @bookId, @takenDate, @broughtDate)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@studentId", System.Data.SqlDbType.Int, 50).Value = studentID;
                command.Parameters.Add("@bookId", System.Data.SqlDbType.Int, 50).Value = bookID;
                command.Parameters.Add("@takenDate", System.Data.SqlDbType.DateTime, 50).Value = DateTime.Now;
                command.Parameters.Add("@broughtDate", System.Data.SqlDbType.DateTime, 50).Value = DBNull.Value;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        //Method to return  borrow
        public void ReturnBook(int bookID, int studentID,  DateTime brDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "UPDATE dbo.borrows SET studentId = @studentId, bookId = @bookId, takenDate = @takenDate, broughtDate = @broughtDate WHERE studentId = @studentId";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@studentId", System.Data.SqlDbType.Int, 50).Value = studentID;
                command.Parameters.Add("@bookId", System.Data.SqlDbType.Int, 50).Value = bookID;
                command.Parameters.Add("@takenDate", System.Data.SqlDbType.DateTime, 50).Value = brDate;
                command.Parameters.Add("@broughtDate", System.Data.SqlDbType.DateTime, 50).Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}