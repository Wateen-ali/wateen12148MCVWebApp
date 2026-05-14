using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wateen12148MCVWebApp.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int roomId { get; set; }
        public string roomName { get;  set; }
        public int roomSize { get; set; }
        public bool isAvailable { get; set; }
        public string location { get; set; }
    }
}