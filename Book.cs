using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Cox_Gabriel_Assign8
{
    //Create a book class
    public class Book
    {
        //Instance Variable's: ID, title, author, yearr, price, and outOfPrint
        private int ID;
        private string title;
        private string author;
        private int year;
        private double price;
        private bool outOfPrint;

        //Constructor
        public Book(string title, string author, int year, double price, bool outOfPrint)
        {
            //We will set the ID based on the database (I THINK)
            this.ID = 0;
            this.title = title;
            this.author = author;
            this.year = year;
            this.price = price;
            this.outOfPrint = outOfPrint;
        }

        //Overriding the ToString method
        public override string ToString()
        {
            string print;
            if (outOfPrint)
            {
                print = "Out of Print";
            }
            else
            {
                print = "In Print";
            }
            return title + ", " + author + ", " + year + ", " + price + ", " + print;
        }

        //Getters 
        public int getID()
        {
            return ID;
        }

        public string getTitle()
        {
            return title;
        }
        
        public string getAuthor()
        {
            return author;
        }

        public int getYear()
        {
            return year;
        }

        public double getPrice()
        {
            return price;
        }

        public bool getOutOfPrint()
        {
            return outOfPrint;
        }

        //Setters
        public void setID(int ID)
        {
            this.ID = ID;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public void setAuthor(string author)
        {
            this.author = author;
        }

        public void setYear(int year)
        {
            this.year = year;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public void setOutOfPrint(bool outOfPrint)
        {
            this.outOfPrint = outOfPrint;  
        }
    }
}
