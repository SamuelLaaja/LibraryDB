using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Model
{
    public partial class Library
    {
        public Library()
        {
            Book = new HashSet<Book>();
            Customer = new HashSet<Customer>();
            Loan = new HashSet<Loan>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public string City { get; set; }

        [InverseProperty("Library")]
        public ICollection<Book> Book { get; set; }
        [InverseProperty("Library")]
        public ICollection<Customer> Customer { get; set; }
        [InverseProperty("Library")]
        public ICollection<Loan> Loan { get; set; }
    }
}
