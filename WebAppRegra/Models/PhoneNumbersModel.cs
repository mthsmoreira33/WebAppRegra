namespace WebAppRegra.Models
{
    public class PhoneNumbersModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int ContactId { get; set; }
        public ContactsModel Contact { get; set; }
    }
}
