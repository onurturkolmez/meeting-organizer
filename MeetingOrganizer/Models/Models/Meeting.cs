using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeetingOrganizer.Models.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        //[Required(AllowEmptyStrings = false,ErrorMessage = "Warning")]
        [Display(Name = "Meeting Subject")]
        [DataType(DataType.Text)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string Header { get; set; }

        [Display(Name ="Meeting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string MeetingDate { get; set; }

        [Display(Name = "Starting Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public string StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public string EndTime { get; set; }

        [Display(Name = "Participants")]
        [DataType(DataType.Text)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string Participants { get; set; }

        public string UpdateTime { get; set; }
    }
}