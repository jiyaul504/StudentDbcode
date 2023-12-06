using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentDbcode.Models;

public partial class TblStudent
{
    public string StudentGid { get; set; } = null!;

    public string StudentName { get; set; }

    public int PlaceofBirth { get; set; }

    public int Nationality { get; set; }

    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DateofBirth { get; set; }


    public int Idtype { get; set; }

    public string? Idnumber { get; set; }

    public int Gender { get; set; }

    public string Phone { get; set; }

    public string FullAddress { get; set; }

    public bool IsActive { get; set; }

    public DateOnly? MDate { get; set; }
    
    
    public DateTime? MDateTime { get; set; }

}
