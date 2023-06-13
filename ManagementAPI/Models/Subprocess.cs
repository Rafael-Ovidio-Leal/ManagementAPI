using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementAPI.Models
{
    public class Subprocess
    {
        public int SubprocessId { get; set; }

        public int? FatherId { get; set; }

        public required string Name { get; set; }

        public required string Responsible { get; set; }

        public required string Description { get; set; }

        public required string Tools { get; set; }

        public required string Technologies { get; set; }

        public required string Status { get; set; }

        public Process? Process { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
