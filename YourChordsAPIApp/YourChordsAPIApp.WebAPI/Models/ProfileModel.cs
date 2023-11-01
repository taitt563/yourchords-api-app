namespace YourChordsAPIApp.WebAPI.Models
{
    public class ProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Gender { get; set; }
        public string Image { get; set; }
    }
}
