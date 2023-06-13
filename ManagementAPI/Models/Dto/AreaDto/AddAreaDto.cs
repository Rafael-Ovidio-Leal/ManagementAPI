namespace ManagementAPI.Models.Dto.AreaDto
{
    public class AddAreaDto
    {
        public required string Name { get; set; }

        public required string Responsible { get; set; }

        public required string Description { get; set; }

        public required string Tools { get; set; }

        public required string Technologies { get; set; }
    }
}
