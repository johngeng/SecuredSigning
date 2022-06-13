using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Field
    {
        public int FieldID { get; set; }
        public string FieldType { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public Field(string fieldName, string fieldValue)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}
