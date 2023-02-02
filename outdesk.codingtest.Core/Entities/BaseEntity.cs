using System.ComponentModel.DataAnnotations;

namespace outdesk.codingtest.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
