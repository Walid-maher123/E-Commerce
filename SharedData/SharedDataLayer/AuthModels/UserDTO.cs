using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.AuthModels
{
    public class UserDTO
    {
        public string Message { get; set; }

        public bool IsAutheried { get; set; }

        public string Token { get; set; }
    }
}
