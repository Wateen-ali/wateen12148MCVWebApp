using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wateen12148MCVWebApp.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId { get; set; }
        public string courseName { get; set; }
        public bool isAvailable { get; set; }

    }
}