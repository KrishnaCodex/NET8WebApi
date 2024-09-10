using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NET8WebApi.Models
{
    public class Share
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? Name { get; set; }

        public int MaxValue { get; set; }

        public int MinValue { get; set; }

    }
}
