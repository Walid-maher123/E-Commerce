using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.AuthModels
{
    public class RegisterDTO
    {

        [Required(ErrorMessage = "The Name Is Required")]
        public string DisplayName { get; set; }


        [Required(ErrorMessage = "The Email Is Required")]
        [EmailAddress(ErrorMessage = "Please Enter Correct Email")]
        public string Email { get; set; }

        [Required(ErrorMessage =" The User Name IS Required ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The PhoneNumeber Is Required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumeber { get; set; }
    }
}
