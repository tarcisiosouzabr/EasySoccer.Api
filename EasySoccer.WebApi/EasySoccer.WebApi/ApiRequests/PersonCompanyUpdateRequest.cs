﻿using System;

namespace EasySoccer.WebApi.ApiRequests
{
    public class PersonCompanyUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
