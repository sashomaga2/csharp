using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CalculatorViewModel
    {
        [Display(Name = "Number 1")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required(ErrorMessage = "Number 1 required")]
        public int Num1 { get; set; }

        [Display(Name = "Number 2")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required(ErrorMessage = "Number 2 required")]
        public int Num2 { get; set; }

        [Display(Name = "Operation")]
        public CalculatorOperation Operation { get; set; }

        public string Result { get; set; }
    }
}
