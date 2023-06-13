namespace ManagementAPI.Models
{
    public class Area
    {
        public int AreaId { get; set; }

        public required string Name { get; set; }

        public required string Responsible { get; set; }

        public required string Description { get; set; }

        public required string Tools { get; set; }

        public required string Technologies { get; set; }

        public required string Status { get; set; }

        public List<Process>? Process { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
