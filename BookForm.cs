namespace Cox_Gabriel_Assign8
{
    public partial class BookForm : Form
    {
        List<Book> books = new List<Book>();

        private void PopulateBookListBox()
        {
            for (int i = 0; i < books.Count(); i++)
            {
                bookListBox.Items.Add(books[i]);
            }
        }

        private static bool checkPrice(string input)
        {
            double number = 0;
            //Make sure the price is a float or integer
            bool isDouble = double.TryParse(input, out number);

            //Make sure price is not negative
            if (number < 0)
            {
                isDouble = false;
            }
            return isDouble;
        }

        private bool checkYear(string input)
        {
            //We need a string that can test the number of digits entered
            string digits = "";

            //We need a boolean to return stating whether the year entered is valid
            //Set it originally to false
            //validYear will only turn to true if the input is an integer AND is 4 digits long.
            bool validYear = false;

            //We need a variable to store the number if int.TryParse is successful
            int number = 0;

            //Is the string passed in an integer? TryParse
            bool isInteger = int.TryParse(input, out number);

            //If it is an integer and the number is not negative
            if (isInteger && number >= 0)
            {
                //Let the digits variable store the digits of the parsed string
                digits = Convert.ToString(number);
            }

            //Finally if the input is an integer and has four digits... It is a valid year
            if (digits.Length == 4)
            {
                validYear = true;
            }
            return validYear;
        }

        public BookForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Validate the user inputs
            string errorMessage = "";
            bool validInputs = true;
            //For title, make sure the string is NOT empty
            if (TitleTxbx.Text == "")
            {
                validInputs = false;
                errorMessage += "Title cannot be empty\n";
            }
            //For author, make sure the string is NOT empty
            if (AuthorTxbx.Text == "")
            {
                validInputs = false;
                errorMessage += "Author cannot be empty\n";
            }
            //For year, use the checkYear method
            if (!(checkYear(YearTxbx.Text)))
            {
                validInputs = false;
                errorMessage += "Year cannot be empty and must be a non-negative integer with 4 digits\n";
            }
            //For price, use the check price method
            if (!(checkPrice(PriceTxbx.Text)))
            {
                validInputs = false;
                errorMessage += "Price cannot be empty and must be a non-negative number\n";
            }

            //If it is not a valid input... produce an appropriate error message 
            if (!validInputs)
            {
                MessageBox.Show(errorMessage, "Error");
            }
            //Otherwise... We want to instantiate a book object
            else
            {
                Book newBook = new Book(TitleTxbx.Text, AuthorTxbx.Text, int.Parse(YearTxbx.Text), double.Parse(PriceTxbx.Text), PrintChbx.Checked);

                //We want to add this book to the database...
                //Use the database helper class to insert this new book
                DatabaseHelper.insertBook(newBook);

                //We also want to add this book to the list of books to store the data if we need it again
                books.Add(newBook);

                //Add the newBook to the list box
                bookListBox.Items.Add(newBook);

                //Finally, clear all fields
                TitleTxbx.Clear();
                AuthorTxbx.Clear();
                YearTxbx.Clear();
                PriceTxbx.Clear();
                PrintChbx.Checked = false;
            }
        }

        //We want to make the delete button delete a selected book in the bookListBox
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //First... Make sure there is a selected item
            //If there is, remove the book at the given index
            if (bookListBox.SelectedItem != null)
            {
                //Remove the corresponding book from the database...
                DatabaseHelper.deleteBookById(books[bookListBox.SelectedIndex].getID());

                //Remove the book at the given index in the books list
                books.RemoveAt(bookListBox.SelectedIndex);

                //Additionally, we want to remove the selectedIndex from the list box
                bookListBox.Items.RemoveAt(bookListBox.SelectedIndex);

                //Finally, clear all fields
                TitleTxbx.Clear();
                AuthorTxbx.Clear();
                YearTxbx.Clear();
                PriceTxbx.Clear();
                PrintChbx.Checked = false;
            }
            else
            {
                MessageBox.Show("Please select a book to delete", "Error");
            }
        }

        //I want my form to unselect anything that the user selected in the list box
        //if they click elsewhere on the form...
        private void BookForm_Click(object sender, EventArgs e)
        {
            bookListBox.ClearSelected();
        }

        //I would like to populate the author, title, year, and price fields
        //again if the user selects a book from the list box
        private void bookListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookListBox.SelectedItem != null)
            {
                //Populate the title textbox again...
                TitleTxbx.Text = books[bookListBox.SelectedIndex].getTitle();

                //Populate the author textbox again...
                AuthorTxbx.Text = books[bookListBox.SelectedIndex].getAuthor();

                //Populate the year textbox again...
                YearTxbx.Text = books[bookListBox.SelectedIndex].getYear().ToString();

                //Populate the price textbox again...
                PriceTxbx.Text = books[bookListBox.SelectedIndex].getPrice().ToString();

                //Check the out of print checkbox appropriately...
                PrintChbx.Checked = books[bookListBox.SelectedIndex].getOutOfPrint();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (bookListBox.SelectedItem != null)
            {
                //Validate the user inputs
                string errorMessage = "";
                bool validInputs = true;
                //For title, make sure the string is NOT empty
                if (TitleTxbx.Text == "")
                {
                    validInputs = false;
                    errorMessage += "Title cannot be empty\n";
                }
                //For author, make sure the string is NOT empty
                if (AuthorTxbx.Text == "")
                {
                    validInputs = false;
                    errorMessage += "Author cannot be empty\n";
                }
                //For year, use the checkYear method
                if (!(checkYear(YearTxbx.Text)))
                {
                    validInputs = false;
                    errorMessage += "Year cannot be empty and must be a non-negative integer with 4 digits\n";
                }
                //For price, use the check price method
                if (!(checkPrice(PriceTxbx.Text)))
                {
                    validInputs = false;
                    errorMessage += "Price cannot be empty and must be a non-negative number\n";
                }

                //If the inputs are invalid show an appropriate error message...
                if (!validInputs)
                {
                    MessageBox.Show(errorMessage, "Error");
                }
                //Otherwise we need to update the books List, the bookFormDB, as well as the string representation in the list box
                else
                {
                    //Update Title
                    books[bookListBox.SelectedIndex].setTitle(TitleTxbx.Text);

                    //Update Author
                    books[bookListBox.SelectedIndex].setAuthor(AuthorTxbx.Text);

                    //Update Year
                    books[bookListBox.SelectedIndex].setYear(int.Parse(YearTxbx.Text));

                    //Update Price
                    books[bookListBox.SelectedIndex].setPrice(float.Parse(PriceTxbx.Text));

                    //Update outOfPrint
                    books[bookListBox.SelectedIndex].setOutOfPrint(PrintChbx.Checked);

                    //We must update the database to record the changes
                    DatabaseHelper.updateBook(books[bookListBox.SelectedIndex]);

                    //Now that the book object has been updated we must update the listBox string
                    bookListBox.Items[bookListBox.SelectedIndex] = books[bookListBox.SelectedIndex];

                    //Finally, clear all fields and make the item in the list box unselected...
                    TitleTxbx.Clear();
                    AuthorTxbx.Clear();
                    YearTxbx.Clear();
                    PriceTxbx.Clear();
                    PrintChbx.Checked = false;
                    bookListBox.ClearSelected();
                }
            }
        }

        //Booting up the form
        private void BookForm_Load(object sender, EventArgs e)
        {
            //We need to connect the bookForm with our book database
            DatabaseHelper.initializeDatabase();

            //Get all books from the database and store them in the list of books
            books.AddRange(DatabaseHelper.getAllBooks());

            //Populate the list box based on the book list we just aquired
            PopulateBookListBox();
        }
    }
}
