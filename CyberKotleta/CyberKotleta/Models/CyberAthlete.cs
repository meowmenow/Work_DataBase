using System;
using System.Collections.Generic;

namespace CyberKotleta.Models;

public partial class CyberAthlete
{
    public int Id { get; set; }

    public string CyberFio { get; set; } = null!;

    public string? Gender { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? CoachFio { get; set; }

    public string? Country { get; set; }

    public string? Dpr { get; set; }

    public string? Impact { get; set; }

    public string? Adr { get; set; }

    public string? Kpr { get; set; }

    public string? Kast { get; set; }

    public string? Photo { get; set; }
}
