using System;
using System.Collections.Generic;

namespace IBE_BACKEND.Models
{
    public partial class UserSearchRequest
    {
        public string UserId { get; set; } = null!;
        public string SearchRequest { get; set; } = null!;
    }
}
