using System;
using System.Collections.Generic;

namespace CyberKotleta.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserFio { get; set; } = null!;

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public int? UserRole { get; set; }

    public virtual Role? UserRoleNavigation { get; set; }
}
