using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumnoService" in both code and config file together.
    [ServiceContract]
    public interface IAlumnoService
    {

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SLWCF.Result GetAll();

        [OperationContract]
        SLWCF.Result Add(ML.Alumno alumno);

        [OperationContract]
        SLWCF.Result Delete(int IdAlumno);

        [OperationContract]
        SLWCF.Result Update(ML.Alumno alunno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SLWCF.Result GetById(int IdAlumno);


    }
}
