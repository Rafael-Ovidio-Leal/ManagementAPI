using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementAPI.Models
{
    public class Process
    {
        public int ProcessId { get; set; }

        public int AreaID { get; set; }

        public Area? Area { get; set; }

        public required string Name { get; set; }

        public required string Responsible { get; set; }

        public required string Description { get; set; }

        public required string Tools { get; set; }

        public required string Technologies { get; set; }

        public required string Status { get; set; }

        public virtual List<Subprocess>? Subprocess { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
