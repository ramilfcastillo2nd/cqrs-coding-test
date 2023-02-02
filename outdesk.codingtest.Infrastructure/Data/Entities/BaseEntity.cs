using System.ComponentModel.DataAnnotations;

namespace outdesk.codingtest.Infrastructure.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
