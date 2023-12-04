using System;
using System.Collections.Generic;

namespace StudentDbcode.Models;

public partial class TblIdtype
{
    public int IdtypeId { get; set; }

    public string? Idtype { get; set; }

    public bool? IsActive { get; set; }
}
