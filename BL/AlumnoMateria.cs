using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BL
{
    public class AlumnoMateria
    {

        public static ML.Result GetMateriasAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {
                    var tablaAlumnoMateria = context.AlumnoMateriaGetAll(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (tablaAlumnoMateria != null)
                    {
                        result.Objects = new List<object>();
                        
                        foreach (var obj in tablaAlumnoMateria)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno;
                            alumnoMateria.Alumno.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = obj.Costo;


                            result.Objects.Add(alumnoMateria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla materia no contiene registros";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }

        public static ML.Result Delete(int IdAlumno, int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {
                    int rowAffected = context.AlumnoMateriaDelete(IdAlumno, IdMateria);
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }

        public static ML.Result GetMateriasNoAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {
                    var tablaAlumnoMateria = context.GetMateriasNoAsignadas(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (tablaAlumnoMateria != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in tablaAlumnoMateria)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = obj.Costo;


                            result.Objects.Add(alumnoMateria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla materia no contiene registros";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }

        public static ML.Result Add(int IdAlumno, int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {
                    int rowAffected = context.AlumnoMateriaAdd(IdAlumno,IdMateria);
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }


    }
}
