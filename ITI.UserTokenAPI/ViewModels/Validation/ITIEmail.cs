using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Validation
{
    public class ITIEmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString().Contains("@iti.gov.eg");
        }
    }
}
