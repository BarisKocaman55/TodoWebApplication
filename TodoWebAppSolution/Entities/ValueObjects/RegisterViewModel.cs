using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("Username"), Required(ErrorMessage = "{0} field is required"), StringLength(35, ErrorMessage = "{0} field can {1} character max")]
        public string Username { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "{0} field is required"),
         StringLength(35, ErrorMessage = "{0} field can {1} character max"),
         EmailAddress(ErrorMessage = "Please Enter a Valid Email !!!")]
        public string Email { get; set; }

        [DisplayName("Password"), Required(ErrorMessage = "{0} field is required!!!"), DataType(DataType.Password), StringLength(35, ErrorMessage = "{0} field can {1} character max")]
        public string Password { get; set; }

        [DisplayName("Password Again"), Required(ErrorMessage = "{0} field is required!!!"),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} field can {1} character max"),
         Compare("Password", ErrorMessage = "{0} and {1} are not match")]
        public string RePassword { get; set; }
    }
}
