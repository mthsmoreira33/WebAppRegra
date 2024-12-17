using System.ComponentModel.DataAnnotations;

namespace WebAppRegra.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PhoneNumbersModel> PhoneNumbers { get; set; } = new List<PhoneNumbersModel>();
    }
}
