using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Model
{
    public partial class Book
    {
        public Book()
        {
            Loan = new HashSet<Loan>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }
        [StringLength(50)]
        public string Genre { get; set; }
        [Required]
        [Column("ISBN")]
        [StringLength(50)]
        public string Isbn { get; set; }
        public int LibraryId { get; set; }

        [ForeignKey("LibraryId")]
        [InverseProperty("Book")]
        public Library Library { get; set; }
        [InverseProperty("Book")]
        public ICollection<Loan> Loan { get; set; }
    }
}
