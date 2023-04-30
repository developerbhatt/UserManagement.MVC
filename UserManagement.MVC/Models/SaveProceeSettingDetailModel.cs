using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.MVC.Models
{
    public class SaveProceeSettingDetailModel
    {
        public Guid Id { get; set; }
        [Required]
        public int ProcessType { get; set; }
        [Required]
        public string ProcessName { get; set; }
        [Required]
        public int SyncTimer { get; set; }
        public DateTime IDate { get; set; }
        public DateTime UDate { get; set; }
    }
}