using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            alumno.Alumnos = new List<object>();

            ServiceReferenceAlumno.AlumnoServiceClient alumnoWCF = new ServiceReferenceAlumno.AlumnoServiceClient();
            //lamando al servicio
            var result = alumnoWCF.GetAll();

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


        [HttpPost]
        public ActionResult GetAll(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.GetAll();
            alumno.Alumnos = result.Objects;

            return View(alumno);
        }


        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            if (IdAlumno != null)
            {
                ML.Result result = BL.Alumno.GetById(IdAlumno.Value);
                // ServiceReferenceUsuario.UsuarioServiceClient usuarioWCF = new ServiceReferenceUsuario.UsuarioServiceClient();
                //lamando al servicio
                // var result = usuarioWCF.Get(usuario);

                if (result.Correct)
                {

                    alumno = (ML.Alumno)result.Object;
                }

            }

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            if (ModelState.IsValid)
            {

                if (alumno.IdAlumno == 0 || alumno.IdAlumno == null)
                {
                    ServiceReferenceAlumno.AlumnoServiceClient alumoWCF = new ServiceReferenceAlumno.AlumnoServiceClient();
                    //WCF
                    var result = alumoWCF.Add(alumno);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha completado el registro";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;
                    }

                }
                else
                {
                    ServiceReferenceAlumno.AlumnoServiceClient alumoWCF = new ServiceReferenceAlumno.AlumnoServiceClient();
                    //WCF
                    var result = alumoWCF.Update(alumno);

                    if (result.Correct)
                    {

                        ViewBag.Mensaje = "Se ha completado la actualizacion";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;
                    }
                }


                return PartialView("Modal");

            }
            else
            {

               
                return PartialView(alumno);
            }
        }


        [HttpGet]
        public ActionResult Delete(int IdAlumno)
        {

            ServiceReferenceAlumno.AlumnoServiceClient alumoWCF = new ServiceReferenceAlumno.AlumnoServiceClient();
            //WCF
            var result = alumoWCF.Delete(IdAlumno);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eleiminado correctamente el usuario";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar el usuario" + result.ErrorMessage;

            }
            return PartialView("Modal");
        }




    }
}