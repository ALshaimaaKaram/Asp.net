using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserToken.Models
{
    public class User : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
