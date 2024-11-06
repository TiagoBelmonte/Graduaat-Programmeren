namespace Assignment.Domain.Models.Reponse
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T>? Result { get; set; }
        public bool? HasMore { get; set; }
        public int? Total { get; set; }
        public int? TotalFiltered { get; set; }
        public int? QuantityPages { get; set; }
        public int? QuantityPagesFiltered { get; set; }
    }
}
