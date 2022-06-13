using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Form
    {
        public int FormID { get; set; }
        public string FormType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Field> Fields { get; set; }

        public Form() {
            Fields = new List<Field>();
        }

        public Form (EmployeeDetails employeeDetails)
        {
            foreach (var prop in employeeDetails.GetType().GetProperties())
            {
                Fields.Add(new Field(prop.Name, prop.GetValue(employeeDetails, null).ToString()));
            }
        }
    }
}
