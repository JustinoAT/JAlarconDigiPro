using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAllAlumnos()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }

            return View(alumno);
        }
        [HttpGet]
        public ActionResult GetMateriasAsignadas(int IdAlumno, string NombreAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriasAsignadas(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Materia = new ML.Materia();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno;
            alumnoMateria.Alumno.Nombre = NombreAlumno;
            alumnoMateria.Materia.Materias = result.Objects;
            return View(alumnoMateria);
        }
        [HttpGet]
        public ActionResult GetMateriasNoAsignadas(int IdAlumno, string NombreAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriasNoAsignadas(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Materia = new ML.Materia();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno;
            alumnoMateria.Alumno.Nombre = NombreAlumno;
            alumnoMateria.Materia.Materias = result.Objects;
            return View(alumnoMateria);
        }


        [HttpGet]
        public ActionResult Delete(int IdAlumno, int IdMateria, string NombreAlumno)
        {

            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Result result = BL.AlumnoMateria.Delete(IdAlumno, IdMateria);
                if (result.Correct)
                {

                    ViewBag.Mensaje = "Materia eliminada correctamente";
                    ViewBag.IdAlumno = IdAlumno;
                   ViewBag.NombreAlumno = NombreAlumno;
                }
                else
                {
                    ViewBag.Mensaje = "No se logro eliminar la materia: " + result.ErrorMessage;
                }

                return PartialView("Modal");
        }


        [HttpPost]
        public ActionResult AddMateria(int IdAlumno, List<int>materias, string NombreAlumno)
        {
            int contador = 0;
            if(materias != null) {
            foreach(int IdMateria1 in materias) { 
              
            ML.Result result = BL.AlumnoMateria.Add(IdAlumno, IdMateria1);
                if (result.Correct)
                {
                    contador++;
                    ViewBag.Mensaje = "Agregaste un total de " + contador + " materias";
                }
                else
                {
                    result.Correct = false;
                }

            }
            ViewBag.IdAlumno = IdAlumno;
            ViewBag.NombreAlumno = NombreAlumno;

            }
            else
            {
                ViewBag.Mensaje = "No seleccionaste ninguna materia";
                ViewBag.IdAlumno = IdAlumno;
                ViewBag.NombreAlumno = NombreAlumno;
            }
            return PartialView("Modal");

        }

    }
}