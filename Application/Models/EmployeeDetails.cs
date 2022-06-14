using System;

namespace Models
{
    public class EmployeeDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullAddress { get; set; }
        public bool? MailingAddressAsAbove { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CitizenshipStatus { get; set; }
        public string EmploymentStartDate { get; set; }
        public string EmploymentType { get; set; }
        public string PositionTitle { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
    }
}
