using Microsoft.Build.Framework;
using System;

namespace UserManagement.MVC.Models
{
    public class SaveProcess
    {
        public Guid Id { get; set; }
        [Required]
        public int ProcessType { get; set; }
        [Required]
        public string ProcessName { get; set; }
        [Required]
        public int SyncTimer { get; set; }
        [Required]
        public string RequestMethodType { get; set; }
        [Required]
        public string RequestURL { get; set; }
        public string RequestBody { get; set; }
        [Required]
        public string ResponseBody { get; set; }
        public DateTime IDate { get; set; }
        public DateTime UDate { get; set; }
    }
}