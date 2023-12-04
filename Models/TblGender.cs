using System;
using System.Collections.Generic;

namespace StudentDbcode.Models;

public partial class TblGender
{
    public int GenderId { get; set; }

    public string? Gender { get; set; }

    public bool? IsActive { get; set; }

    //public ICollection<TblStudent> tblStudent { get; set; }
}
