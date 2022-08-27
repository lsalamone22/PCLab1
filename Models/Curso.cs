using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace PCLab1.Models
{
    public class Curso
    {
        [Display(Name = "First Name", Prompt = "Enter your First Name")]
        public string? nombre{get; set;}
         [Display(Name = "Last Name", Prompt = "Enter your Last Name")]
        public string? apellido{get; set;}

        
        //CHECKBOX DE NOMCURSO
        [Required(ErrorMessage = "Course Required")]
         [Display(Name = "Course :")]
        public curso? nomCurso { get; set; }
        public List<curso>? CursoList { get; set; }

    }


     public class curso
    {
        public string? ID {get;set;}
    
        public string? Type {get;set;}
        public bool active {get;set;}
    }

}