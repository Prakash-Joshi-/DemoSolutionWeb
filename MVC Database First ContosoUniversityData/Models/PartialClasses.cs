using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Database_First_ContosoUniversityData.Models
{
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
        public int EnrolledDuration { get { return Convert.ToInt32(System.DateTime.UtcNow.Date.Year - EnrollmentDate.Value.Year); } }
    }
    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {

    }
}