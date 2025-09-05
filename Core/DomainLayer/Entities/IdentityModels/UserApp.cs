﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.IdentityModels
{
    public class UserApp : IdentityUser
    {
        public string DisplayName { get; set; } = null!;

        public Address? Address { get; set; } = null!;
    }
}
