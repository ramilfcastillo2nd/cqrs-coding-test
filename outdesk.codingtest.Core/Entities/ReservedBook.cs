using System.ComponentModel.DataAnnotations.Schema;

namespace outdesk.codingtest.Core.Entities
{
    public class ReservedBook : BaseEntity
    {
        public int BookingNumber { get; set; }
        public Guid BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
