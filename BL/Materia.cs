using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {
                    int rowAffected = context.MateriaAdd(materia.Nombre, materia.Costo);
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

        //----------------------Metodo Update-------------

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {

                    int rowAffected = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);
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
        //----------------------Metodo Borrar-------------

        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {
                    int rowAffected = context.MateriaDelete(IdMateria);
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
        //----------------------Metodo select *-------------

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {
                    var tablaMaterias = context.MateriaGetAll().ToList();
                    result.Objects = new List<object>();

                    if (tablaMaterias != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in tablaMaterias)
                        {
                            ML.Materia materia1 = new ML.Materia();
                            materia1.IdMateria = obj.IdMateria;
                            materia1.Nombre = obj.Nombre;
                            materia1.Costo = obj.Costo;
                

                            result.Objects.Add(materia1);
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

        //----------------------Metodo select by ID-------------

        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconControlEscolarEntities context = new DL.JAlarconControlEscolarEntities())
                {

                    var tablaMateriasId = context.MateriaGetById(IdMateria).FirstOrDefault();


                    if (tablaMateriasId != null)
                    {

                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = tablaMateriasId.IdMateria;
                        materia.Nombre = tablaMateriasId.Nombre;
                        materia.Costo = tablaMateriasId.Costo;
                        result.Object = materia;
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










    }
}
