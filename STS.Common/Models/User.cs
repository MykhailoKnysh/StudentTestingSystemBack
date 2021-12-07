﻿using System;
using System.Collections.Generic;

namespace STS.Common.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<Guid> GroupIds { get; set; }
    }
}