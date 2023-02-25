using Dapper;
using Incident.SOR.Application.Persistence;
using Incident.SOR.Core.Persistence;
using Incident.SOR.Core.Utility;
using Incident.SOR.Domain.DTO;
using Incident.SOR.Domain.DTO.Request;
using static Slapper.AutoMapper;


namespace Incident.SOR.Infrastructure.Persistence
{
    public class IncidentService : IRepository<IncidentDto>
    {
        private readonly IDataAccessBase dataAccess;
        public IncidentService(IDataAccessBase dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<Guid> AddAsync(IncidentDto record)
        {
            Guid id = Guid.NewGuid();
            string insertQuery = @"INSERT INTO Incident (Id, Color, Name, Description, CreatedDate, UpdatedDate, UpdatedBy)
                                   VALUES
                                   (@Id, @Color, @Name, @Description, GETDATE(), GETDATE(), @UpdatedBy)";

            var param = new DynamicParameters();
            param.Add("@Id", id);
            param.Add("@Color", record.Color);
            param.Add("@Name", record.Name);
            param.Add("@Description", record.Description);
            param.Add("@UpdatedBy", record.UpdatedBy);

            int resultCount = await dataAccess.ExecuteNonQueryAsync(insertQuery, param, System.Data.CommandType.Text);
            return resultCount > 0 ? id : Guid.Empty;
        }

        public async Task<bool> DeleteAsync(int systemId)
        {
            string deleteQuery = "DELETE FROM Incident WHERE SystemId = @SystemId";

            var param = new DynamicParameters();
            param.Add("@SystemId", systemId);

            int resultCount = await dataAccess.ExecuteNonQueryAsync(deleteQuery, param, System.Data.CommandType.Text);
            return resultCount > 0;
        }


        public async Task<IncidentDto?> UpdateAsync(int systemId, IncidentDto record)
        {
            string updateQuery = @"UPDATE Incident SET Color = @Color, Name = @Name, 
                                Description = @Description, UpdatedDate = GETDATE(), 
                                UpdatedBy = @UpdatedBy WHERE SystemId = @SystemId";

            var param = new DynamicParameters();
            param.Add("@SystemId", record.SystemId);
            param.Add("@Color", record.Color);
            param.Add("@Name", record.Name);
            param.Add("@Description", record.Description);
            param.Add("@UpdatedBy", record.UpdatedBy);

            int resultCount = await dataAccess.ExecuteNonQueryAsync(updateQuery, param, System.Data.CommandType.Text);
            return resultCount > 0 ? record : null;
        }

        public async Task<IncidentDto> GetAsync(int systemId)
        {
            string getQuery = $@"SELECT {SqlHelper.GenerateColumnsSelectQuery(new IncidentDto())} 
                              FROM Incident WITH (NOLOCK) WHERE SystemId = @SystemId";
            var param = new DynamicParameters();
            param.Add("@SystemId", systemId);
            return await dataAccess.QueryFirstOrDefaultAsync<IncidentDto>(getQuery, param, System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<IncidentDto>> GetManyAsync()
        {
            string baseQuery = $"SELECT {SqlHelper.GenerateColumnsSelectQuery(new IncidentDto())} FROM Incident WITH (NOLOCK)";
            return await dataAccess.QueryListAsync<IncidentDto>(baseQuery, null, System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<IncidentDto>> GetManyAsync(FilterRequestDto filterRequest)
        {
            string baseQuery = $"SELECT {SqlHelper.GenerateColumnsSelectQuery(new IncidentDto())} FROM Incident WITH (NOLOCK)";
            return await dataAccess.QueryListAsync<IncidentDto>(baseQuery, null, System.Data.CommandType.Text);
        }

        public async Task<int> CountRecordsAsync()
        {
            string baseQuery = $"SELECT COUNT(1) FROM Incident WITH (NOLOCK)";
            return await dataAccess.QuerySingleOrDefaultAsync<int>(baseQuery, null, System.Data.CommandType.Text);
        }
    }
}
