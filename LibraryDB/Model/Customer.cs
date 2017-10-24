using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Loan = new HashSet<Loan>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string LibraryCardNumber { get; set; }
        public int LibraryId { get; set; }

        [ForeignKey("LibraryId")]
        [InverseProperty("Customer")]
        public Library Library { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Loan> Loan { get; set; }
    }
}
