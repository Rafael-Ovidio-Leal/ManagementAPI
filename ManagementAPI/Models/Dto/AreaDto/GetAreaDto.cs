using ManagementAPI.Models.Dto.ProcessDto;

namespace ManagementAPI.Models.Dto.AreaDto
{
    public class GetAreaDto
    {
        public int AreaId { get; set; }

        public required string Name { get; set; }

        public required string Responsible { get; set; }

        public required string Description { get; set; }

        public required string Tools { get; set; }

        public required string Technologies { get; set; }

        public required string Status { get; set; }

        public List<GetProcessDto>? Process { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
