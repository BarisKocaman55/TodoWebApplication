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
    [Table("Todo")]
    public class Todo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Description"), StringLength(100, ErrorMessage = "{0} field can be {1} charcter maximum"), Required(ErrorMessage = "{0} field is required")]
        public string Description { get; set; }

        [DisplayName("Is Completed")]
        public bool IsDone { get; set; }

        public int OwnerId { get; set; }
        public virtual User User { get; set; }

    }
}
