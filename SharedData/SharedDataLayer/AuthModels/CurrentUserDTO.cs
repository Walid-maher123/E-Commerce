using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataLayer.AuthModels
{
    public class CurrentUserDTO
    {
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
