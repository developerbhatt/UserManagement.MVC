using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.MVC.Models
{
    public class SourceLoginAPIModel
    {
        public Guid Id { get; set; }
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
