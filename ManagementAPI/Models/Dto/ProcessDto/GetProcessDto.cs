using ManagementAPI.Models.Dto.SubprocessDto;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementAPI.Models.Dto.ProcessDto
{
    public class GetProcessDto
    {
        public int ProcessId { get; set; }

        public required string Name { get; set; }

        public required string Responsible { get; set; }

        public required string Description { get; set; }

        public required string Tools { get; set; }

        public required string Technologies { get; set; }

        public required string Status { get; set; }

        [NotMapped]
        public List<Area>? area { get; set; }

        public List<GetSubprocessDto>? Subprocesses { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
