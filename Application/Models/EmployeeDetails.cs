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

        public bool IsValid()
        {
            var result = true;
            result = result && !string.IsNullOrEmpty(FirstName);
            result = result && !string.IsNullOrEmpty(LastName);
            result = result && !string.IsNullOrEmpty(FullAddress);
            result = result && !string.IsNullOrEmpty(EmailAddress);
            result = result && !string.IsNullOrEmpty(PhoneNumber);
            result = result && !string.IsNullOrEmpty(CitizenshipStatus);
            result = result && !string.IsNullOrEmpty(EmploymentStartDate) && DateTime.TryParse(EmploymentStartDate, out var startDate);
            result = result && !string.IsNullOrEmpty(EmploymentType);
            result = result && !string.IsNullOrEmpty(PositionTitle);
            result = result && !string.IsNullOrEmpty(EmergencyContactName);
            result = result && !string.IsNullOrEmpty(EmergencyContactRelationship);
            result = result && !string.IsNullOrEmpty(EmergencyContactPhoneNumber);

            return result;
        }
    }
}
