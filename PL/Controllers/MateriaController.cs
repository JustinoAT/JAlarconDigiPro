using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();
            ML.Result result = new ML.Result();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var responseTask = client.GetAsync("materia");
                responseTask.Wait();    
                var resultServicio = responseTask.Result;
                if(resultServicio.IsSuccessStatusCode)
                {
                    var readTask =resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();    
                    foreach(var resultMateria in readTask.Result.Objects) {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultMateria.ToString());
                        materia.Materias.Add(resultItemList);
                    }
                }
            }

            return View(materia);
        }


        [HttpPost]
        public ActionResult GetAll(ML.Materia materia)
        {
            ML.Result result = BL.Materia.GetAll();
            materia.Materias = result.Objects;

            return View(materia);
        }
        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = new ML.Result();

            if (IdMateria != null) //UPdate
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    var responseTask = client.GetAsync("materia/" + IdMateria);
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                        materia = resultItemList;
                        result.Correct = true;
                    }

                }
              
               
            }
            return View(materia);
        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (ModelState.IsValid)
            {
               
                if (materia.IdMateria ==0) //ADD
                {
                    ML.Result result = new ML.Result();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                        var responseTask = client.PostAsJsonAsync<ML.Materia>("materia",materia);
                        responseTask.Wait();
                        var resultApi = responseTask.Result;
                        if (resultApi.IsSuccessStatusCode)
                        {
                            result.Correct = true;
                            ViewBag.Mensaje = "Materia agregada correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "No se pudo agregar la materia, Error en: " + result.ErrorMessage;
                        }
                    }
                }
                else //UPDATE
                {
                    ML.Result result = new ML.Result();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                        var responseTask = client.PutAsJsonAsync<ML.Materia>("materia/" + materia.IdMateria, materia);
                        responseTask.Wait();
                        var resultApi = responseTask.Result;
                        if (resultApi.IsSuccessStatusCode)
                        {
                            result.Correct = true;
                        }
                    }
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Materia actualizada correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo actualizar la materia, Error en: " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                return PartialView(materia);
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = new ML.Result();

            using (var client = new HttpClient()) {

                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var responseTask = client.DeleteAsync("materia/" + IdMateria);
                responseTask.Wait();
                var resultApi = responseTask.Result;
                if (resultApi.IsSuccessStatusCode)
                {
                    result.Correct = true;
                }
                if(result.Correct)
                {
                    ViewBag.Mensaje = "Materia eliminada correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se logro eliminar la materia: " + result.ErrorMessage;
                }

                return PartialView("Modal");
            }
        }
    }
}