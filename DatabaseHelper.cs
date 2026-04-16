using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cox_Gabriel_Assign8
{
    public static class DatabaseHelper
    {
        //This method creates a book database to store our bookForm data in
        //if the database does not exist already.
        //It also creats a book table if it does not exist already.
        public static void initializeDatabase()
        {
            //We need a name for our database file
            //Since it is a book database in sqlite lets call it books.sqlite
            string databaseFile = "bookFormDB.sqlite";

            //We need a string that can establish a connection between our code and the books.sqlite file
            string ConnectionString = $"DataSource={databaseFile};Version=3;";

            //If the file does not exist yet, 
            //we should probably make the file...
            if (!File.Exists(databaseFile))
            {
                SQLiteConnection.CreateFile(databaseFile);

                //Lets include a statement in the debug window so we know when the file is created
                Debug.WriteLine("---Created databaseFile---");
            }

            //We need to make a book table as well
            //First connect to the database file
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                //Open the connection to the database
                //We will need to close this later
                connection.Open();

                //Make a SQL string that will create a new table if it does not already exist
                //with the following columns:
                //id (INTEGER PRIMARY KEY AUTOINCREMENT),
                //title (STRING NOT NULL),
                //author (STRING NOT NULL),
                //year (INTEGER NOT NULL),
                //price (REAL NOT NULL),
                //isOutOFPrint (INTEGER NOT NULL)
                string createTableSQL = @"
                CREATE TABLE IF NOT EXISTS Books (
	                ID INTEGER PRIMARY KEY AUTOINCREMENT,
	                Title TEXT NOT NULL,
	                Author TEXT NOT NULL,
	                Year INTEGER NOT NULL,
	                Price REAL NOT NULL,
	                IsOutOfPrint INTEGER NOT NULL
                );
                ";

                //Execute the SQL string we just created
                SQLiteCommand command = new SQLiteCommand(createTableSQL, connection);
                command.ExecuteNonQuery();

                //Finally, we must close the connection to the database
                connection.Close();
            }
        }



        //This method connects with our book database, retrives the data,
        //and returns a list of book objects
        public static List<Book> getAllBooks()
        {
            //We need to make a list of type book to store the data from the database
            List<Book> books = new List<Book>();

            //We need the name of our database to stay consistent
            string databaseFile = "bookFormDB.sqlite";

            //We need a string that can establish a connection between our code and the books.sqlite file
            string ConnectionString = $"DataSource={databaseFile};Version=3;";

            //Establish our connection to the database
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                //Open the connection
                connection.Open();

                //We need to read all of the data from the book database...
                //First select all of the books so we can read them...
                SQLiteCommand command = new SQLiteCommand("Select * From Books", connection);
                SQLiteDataReader reader = command.ExecuteReader();

                //While there is still more data to read, read the data and
                //instantiate a corresponding book object.
                while (reader.Read())
                {

                    string title = Convert.ToString(reader["Title"]);
                    string author = Convert.ToString(reader["Author"]);
                    int year = Convert.ToInt32(reader["Year"]);
                    double price = Convert.ToDouble(reader["Price"]);
                    bool isOutOfPrint = Convert.ToBoolean(reader["IsOutOfPrint"]);

                    //Instantiate a new book object
                    Book newBook = new Book(title, author, year, price, isOutOfPrint);

                    //We now need to set the ID variable in the book object to match the database
                    newBook.setID(Convert.ToInt32(reader["ID"]));

                    //Add it to the list that will be returned from the function
                    books.Add(newBook);
                }
                connection.Close();
            }
            return books;
        }



        //This method opens the bookForm database and adds a book
        public static void insertBook(Book book)
        {
            //We need the name of our database to stay consistent
            string databaseFile = "bookFormDB.sqlite";

            //We need a string that can establish a connection between our code and the books.sqlite file
            string ConnectionString = $"DataSource={databaseFile};Version=3;";

            //Establish our connection to the database
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                //Open the connection
                connection.Open();

                //We need a string command to insert a new book into the database
                string insertSQL = @"INSERT INTO Books (Title, Author, Year, Price, IsOutOfPrint)
                                     VALUES (@Title, @Author, @Year, @Price, @IsOutOfPrint)";

                //Create a SQLiteCommand
                using (SQLiteCommand command = new SQLiteCommand(insertSQL, connection))
                {
                    //Enter the values to be entered in each field of the database entry
                    command.Parameters.AddWithValue("@Title", book.getTitle());
                    command.Parameters.AddWithValue("@Author", book.getAuthor());
                    command.Parameters.AddWithValue("@Year", book.getYear());
                    command.Parameters.AddWithValue("@Price", book.getPrice());
                    command.Parameters.AddWithValue("@IsOutOfPrint", book.getOutOfPrint());

                    //Execute the command
                    command.ExecuteNonQuery();
                }

                //Set the ID of the book object to match the ID in the database...
                book.setID((int)connection.LastInsertRowId);

                //Close the connection to the database
                connection.Close();
            }
        }



        //This function opens the bookForm database and deletes a book at a specific index
        public static void deleteBookById(int id)
        {
            //We need the name of our database to stay consistent
            string databaseFile = "bookFormDB.sqlite";

            //We need a string that can establish a connection between our code and the books.sqlite file
            string ConnectionString = $"DataSource={databaseFile};Version=3;";

            //Establish our connection to the database
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                //Open the connection
                connection.Open();

                //We need a SQLite string that will delete an entry from our database
                //given a specific ID
                string deleteSQL = $"DELETE FROM Books WHERE ID = {id}";

                //Create the command
                SQLiteCommand command = new SQLiteCommand(deleteSQL, connection);

                //Execute the command
                command.ExecuteNonQuery();

                //Close the connection to the database
                connection.Close();

            }
        }



        //This function updates the data in the bookForm database for a book at a specific index
        //given the corresponding book in the bookForm application
        public static void updateBook(Book book)
        {
            //We need the name of our database to stay consistent
            string databaseFile = "bookFormDB.sqlite";

            //We need a string that can establish a connection between our code and the books.sqlite file
            string ConnectionString = $"DataSource={databaseFile};Version=3;";

            //Establish our connection to the database
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                //Open the connection
                connection.Open();

                //We need a SQLite string that updates a book with the
                //same values as the book passed into the function
                //Also... We need to make sure the index of book in the database
                //matches the index of the book in the bookForm application
                
                //Convert out of print to a zero or one to store in the database
                int outOfPrint;
                outOfPrint = 0;
                if (book.getOutOfPrint())
                {
                    outOfPrint = 1;
                }

                //After mannnnnny errors, I realize if a string contains an apostrophe,
                //we must escape it when it is used in an SQL query...
                //Lets start by making a proper string to use for title in our SQL query
                string titleForSQL = "";
                string bookTitle = book.getTitle();
                for (int i = 0; i < bookTitle.Length; i++) 
                {
                    titleForSQL += bookTitle[i];
                    if (bookTitle[i] == '\'')
                    {
                        titleForSQL += "'";
                    }
                    
                }

                //Lets do the same for author
                string authorForSQL = "";
                string bookAuthor = book.getAuthor();
                for (int i = 0; i < bookAuthor.Length; i++)
                {
                    authorForSQL += bookAuthor[i];
                    if (bookAuthor[i] == '\'')
                    {
                        authorForSQL += "'";
                    }
                }
                
                
                //Loop through the title to find any apostrophe's 

                string updateSQL = @$"UPDATE Books 
                                      SET Title = '{titleForSQL}', 
                                      Author = '{authorForSQL}', 
                                      Year = {book.getYear()}, 
                                      Price = {book.getPrice()}, 
                                      IsOutOfPrint = {outOfPrint} 
                                      WHERE ID = {book.getID()};";

                //Now that we have the SQL code we wish to execute in the database, 
                //we need to make a new command and execute it... 
                SQLiteCommand command = new SQLiteCommand(updateSQL, connection);
                command.ExecuteNonQuery();

                //Close the connection
                connection.Close();
            }
        }
    }
}
