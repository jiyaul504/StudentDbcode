using System;
using System.Collections.Generic;

namespace StudentDbcode.Models;

public partial class TblCountry
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public bool? IsActive { get; set; }



    // Navigation property for the Employee relationship
    //public ICollection<TblStudent> tblStudent { get; set; }


}
