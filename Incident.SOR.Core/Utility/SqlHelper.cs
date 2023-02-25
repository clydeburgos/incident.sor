using Incident.SOR.Domain.DTO.Request;
using System.Reflection;

namespace Incident.SOR.Core.Utility
{
    public class SqlHelper
    {
        public static string SqlFilterPagingQueryBuilder(FilterRequestDto filterRequestDto, string baseQuery, string whereQuery = "", string orderByQuery = "")
        {
            baseQuery += !string.IsNullOrEmpty(filterRequestDto.SearchValue) ? whereQuery : string.Empty;
            baseQuery += !string.IsNullOrEmpty(orderByQuery) ? orderByQuery : string.Empty;

            int page = filterRequestDto.Page <= 0 ? 1 : filterRequestDto.Page;
            int take = filterRequestDto.Take <= 0 ? 25 : filterRequestDto.Take;

            return $"{baseQuery} OFFSET {(page - 1) * take} ROWS FETCH NEXT {take} ROWS ONLY;";
        }

        public static string GenerateColumnsSelectQuery<TModel>(TModel cls, string alias = "") where TModel : class
        {
            string query = string.Empty;
            PropertyInfo[] properties;
            string aliasHandler = !string.IsNullOrEmpty(alias) ? alias + "." : "";
            properties = typeof(TModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var fields = string.Join(", ", properties.Select(p => $"{aliasHandler}[" + p.Name + "]"));
            return fields;
        }
    }
}
