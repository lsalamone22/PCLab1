using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCLab1.Models; //AGREGAMOS


namespace PCLab1.Controllers
{
    
    public class Pc1FormController : Controller
    {
        private readonly ILogger<Pc1FormController> _logger;

        public Pc1FormController(ILogger<Pc1FormController> logger)
        {
            _logger = logger;
        }

        public IActionResult VistaPcForm()
        {
            return View("VistaPcForm");
        }

[HttpPost]
        public IActionResult create(Curso objCurso)
        {
            string? nom=null, ape=null;
             nom = objCurso.nombre;
             ape = objCurso.apellido;
            int credito =3, subtotal=0,  valorxCredito=100;
            double total=0, igv=0;
            
            //GUARDAR CURSO EN UNA VARIABLE
             //bool active;

            string listaCurso=null;
            List<curso> course = objCurso.CursoList;

            //listaSexo = objPersona.SexList == null ? "1" : "0";
            // si es nullo  1, sino es 0

            for (int i = 0; i < course.Count; i++){
                if(course[i].active == true){
                    listaCurso += course[i].Type+ " ";
                    subtotal += (credito * valorxCredito);
                }
                
            } 

            total = subtotal*1.18;
            igv = total-subtotal;

            ViewData["Message"] =  nom + " " + ape + " , you are already register on the following course(s):";
            ViewData["Message1"] = "Course: " + listaCurso ;
            ViewData["Message2"] = "Subtotal: " + subtotal;
            ViewData["Message3"] = "IGV: " + igv; 
            ViewData["Message4"] = "Total: " + total; 
            
            return View("VistaSubmit");
        }


[HttpGet]
public ActionResult VistaPcForm(Curso objCurso)
{
   
       var cursos = new Curso 
    {
        //CHECKBOX CURSO 
       CursoList = new List<curso>
        {
            new curso{ID="1" , Type = "Matematica"}, 
            new curso{ID="2" , Type = "Lenguaje"},
             new curso{ID="3" , Type = "Historia"}
        }   , 

         
    } ;   

    return View(cursos);//ENVIAMOS LA VARIABLE VAR
}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}