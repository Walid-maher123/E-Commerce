using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.AuthModels
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="The Email Is required")]
        [EmailAddress (ErrorMessage =" Enter Correct Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="The Password Is Required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
