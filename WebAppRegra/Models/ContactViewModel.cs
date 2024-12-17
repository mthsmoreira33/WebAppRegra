namespace WebAppRegra.Models
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        public int PhoneNumberId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberType { get; set; }
        public IEnumerable<PhoneNumbersModel> PhoneNumbers { get; set; }
    }
}
