using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Model
{
    public partial class Loan
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LoanDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public int LibraryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("BookId")]
        [InverseProperty("Loan")]
        public Book Book { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Loan")]
        public Customer Customer { get; set; }
        [ForeignKey("LibraryId")]
        [InverseProperty("Loan")]
        public Library Library { get; set; }
    }
}
