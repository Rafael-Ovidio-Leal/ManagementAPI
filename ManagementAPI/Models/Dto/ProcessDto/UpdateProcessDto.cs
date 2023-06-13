namespace ManagementAPI.Models.Dto.ProcessDto
{
    public class UpdateProcessDto
    {
        public int ProcessId { get; set; }

        public int AreaId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Responsible { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Tools { get; set; } = string.Empty;

        public string Technologies { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
