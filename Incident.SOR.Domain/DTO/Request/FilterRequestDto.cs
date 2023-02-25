namespace Incident.SOR.Domain.DTO.Request
{
    public class FilterRequestDto
    {
        private int _take = 25;
        public int Take
        {
            get => _take;
            set
            {
                if (value > 0)
                {
                    _take = value;
                }
            }
        }
        public int Page { get; set; } = 0;
        public string? SearchValue { get; set; }
    }
}
