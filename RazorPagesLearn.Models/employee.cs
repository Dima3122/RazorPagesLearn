using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLearn.Models
{
    public class employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя не может быть пустым")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email не может быть пустым")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}
