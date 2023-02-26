using Incident.SOR.Application.Persistence;
using Incident.SOR.Domain.DTO;
using Incident.SOR.Domain.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incident.SOR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IRepository<IncidentDto> repository;
        public IncidentController(IRepository<IncidentDto> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{systemId}")]
        public async Task<IActionResult> GetAsync(int systemId)
        {
            var data = await repository.GetAsync(systemId);
            return Ok(data);
        }

        [HttpGet("many")]
        public async Task<IActionResult> GetManyAsync(string ? search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var data = await repository.GetManyAsync(new FilterRequestDto() { 
                    SearchValue = search
                });
                return Ok(data);
            }
            else 
            {
                var data = await repository.GetManyAsync();
                return Ok(data);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(IncidentAddRequestDto record)
        {
            var incidentRecord = new IncidentDto()
            {
                Name = record.Name,
                Color = record.Color,
                Description = record.Description,
                UpdatedBy = string.IsNullOrEmpty(record.UpdatedBy) ? "System" : record.UpdatedBy
            };
            var data = await repository.AddAsync(incidentRecord);
            return Ok(data);
        }

        [HttpPut("update/{systemId}")]
        public async Task<IActionResult> UpdateAsync(int systemId, IncidentDto record)
        {
            var data = await repository.UpdateAsync(systemId, record);
            return Ok(data);
        }

        [HttpDelete("delete/{systemId}")]
        public async Task<IActionResult> DeleteAsync(int systemId)
        {
            var data = await repository.DeleteAsync(systemId);
            return Ok(data);
        }
    }
}
