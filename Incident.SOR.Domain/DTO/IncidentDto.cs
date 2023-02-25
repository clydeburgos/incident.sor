using System;namespace Incident.SOR.Domain.DTO
{
    public class IncidentDto
    {
        public int SystemId { get; set; }
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
