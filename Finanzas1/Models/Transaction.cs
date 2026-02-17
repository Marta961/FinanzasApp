namespace Finanzas1.Models
{
    public class Transaction
    {
        public int Id { get; set; }                 // PK
        public DateTime Date { get; set; } = DateTime.Today;
        public string Description { get; set; } = "";
        public decimal Amount { get; set; }         // +income, -expense (or add Type)
        public string Category { get; set; } = "";
    }
}
