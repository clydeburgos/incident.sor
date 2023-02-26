using Incident.SOR.Domain.DTO.Request;
using System;namespace Incident.SOR.Domain.DTO
{
    public class IncidentDto : IncidentAddRequestDto
    {
        public int SystemId { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
