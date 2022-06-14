using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Models
{
    public class Form
    {
        public int FormID { get; set; }
        public FormType FormType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Field> Fields { get; set; }

        public Form() {
            Fields = new List<Field>();
        }

        public Form (FormType formType, List<Field> templateFields, string description, EmployeeDetails employeeDetails)
        {
            FormType = formType;
            Description = string.IsNullOrEmpty(description) ? typeof(EmployeeDetails).Name : description;
            Fields = new List<Field>();

            foreach (var prop in employeeDetails.GetType().GetProperties())
            {
                var field = templateFields.FirstOrDefault(t => t.FieldName.Equals(prop.Name));
                if (field!=null)
                {
                    Fields.Add(new Field(field.FieldID, field.FieldType, prop.Name, prop.GetValue(employeeDetails, null)?.ToString()));
                }
            }
        }
    }

    public enum FormType
    {
        PDF
    }
}
