using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace l4.Models
{
    [Table(name: "BookOutOfStorage")]
    public class BookOutOfStorage
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public DateTime BookTakeDate { get; set; }
        public DateTime BookReturnDate { get; set; }


        public Person Person { get; set; }
        public Book Book { get; set; }
    }
}
