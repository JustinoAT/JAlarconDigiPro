using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;
using ML;
namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlumnoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlumnoService.svc or AlumnoService.svc.cs at the Solution Explorer and start debugging.
    public class AlumnoService : IAlumnoService
    {
        public SLWCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            SLWCF.Result resultwcf = new SLWCF.Result();
            resultwcf.Correct = result.Correct;
            return resultwcf;
        }
        public SLWCF.Result Delete(int IdAlumno)
        {
            ML.Result result = BL.Alumno.Delete(IdAlumno);
            SLWCF.Result resultwcf = new SLWCF.Result();
            resultwcf.Correct = result.Correct;
            return resultwcf;
        }

        public SLWCF.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            SLWCF.Result resultwcf = new SLWCF.Result();
            resultwcf.Correct = result.Correct;
            return resultwcf;
        }
        public Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            SLWCF.Result resultWCF = new SLWCF.Result();
            resultWCF.Correct = result.Correct;
            resultWCF.ErrorMessage = result.ErrorMessage;
            resultWCF.Object = result.Object;
            resultWCF.Objects = result.Objects;
            resultWCF.Ex = result.Exception;

            return resultWCF;
        }
        public Result GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);
            SLWCF.Result resultWCF = new SLWCF.Result();
            resultWCF.Correct = result.Correct;
            resultWCF.ErrorMessage = result.ErrorMessage;
            resultWCF.Object = result.Object;
            resultWCF.Objects = result.Objects;
            resultWCF.Ex = result.Exception;

            return resultWCF;
        }
    }
}
