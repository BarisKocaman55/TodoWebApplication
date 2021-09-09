using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Name"), StringLength(50, ErrorMessage = "{0} field can be {1} charcter maximum")]
        public string Name { get; set; }

        [DisplayName("Surname"), StringLength(50, ErrorMessage = "{0} field can be {1} charcter maximum")]
        public string Surname { get; set; }

        [DisplayName("Username"), Required(ErrorMessage = "{0} field is required"), StringLength(50, ErrorMessage = "{0} field can be {1} charcter maximum")]
        public string Username { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "{0} field is required"), StringLength(50, ErrorMessage = "{0} field can be {1} charcter maximum")]
        public string Email { get; set; }

        [DisplayName("Password"), Required(ErrorMessage = "{0} field is required"), StringLength(50, ErrorMessage = "{0} field can be {1} charcter maximum")]
        public string Password { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        public virtual List<Todo> Todos { get; set; }

        public User()
        {
            Todos = new List<Todo>();
        }
    }
}
