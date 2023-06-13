namespace ManagementAPI.Models.Dto.SubprocessDto
{
    public class AddSubprocessDto
    {
        public required string Name { get; set; }

        public required int ProcessId { get; set; }

        public required int FatherId { get; set; }

        public required string Responsible { get; set; }

        public required string Description { get; set; }

        public required string Tools { get; set; }

        public required string Technologies { get; set; }
    }
}
