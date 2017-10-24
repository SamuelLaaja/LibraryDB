using System;
using System.Linq;
using LibraryDB.Model;
using Microsoft.EntityFrameworkCore;

// https://docs.microsoft.com/en-us/ef/core/querying/async
namespace LibraryDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LibrarydbContext();

            //// Adds new Library entity
            //var newLibrary = new Library
            //{
            //    Name = "Testi kirjasto",
            //    PhoneNumber = "894165498",
            //    StreetAddress = "Testikatu 1",
            //    City = "Lappeenranta",
            //    PostalCode = "54545",
            //};

            //context.Library.Add(newLibrary);
            //context.SaveChanges();

            var library = context.Library.Where(l => l.Id == 7).FirstOrDefault();

            library.Name = "Muutettu nimi";
            context.Library.Update(library);
            context.SaveChanges();

            // .ToListAsync().Result negates asynchronity. 
			// It waits for result. But allows other programs to run while waiting...
            var libraries = context.Library
                //.Where(l => l.Id == 1)
                .Include(l => l.Book)
                .Include(l => l.Customer)
                .Include(l => l.Loan)
                .ToListAsync().Result;

            Console.ReadKey();
        }

        // Lambda expression equivalent
        private bool DoSomething(Library library)
        {
            if (library.Id == 4)
            {
                return true;
            }
            return false;
        }
    }
}