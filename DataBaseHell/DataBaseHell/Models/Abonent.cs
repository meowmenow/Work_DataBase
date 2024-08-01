﻿using System;
using System.Collections.Generic;

namespace DataBaseHell.Models;

public partial class Abonent
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime? Age { get; set; }

    public string? Inn { get; set; }

    public string? Phone { get; set; }

    public byte[]? Photo { get; set; }
}