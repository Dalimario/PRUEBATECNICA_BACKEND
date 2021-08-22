using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{



	[OperationContract]
	UserModel AuthenticateUser(LoginViewModel Accesos);

	[OperationContract]
	List<ConsultaAlumnosViewModel>  ConsultaAlumnos();

	[OperationContract]
	Response InsertarAlummnos(CrearAlumnoViewModel crearAlumnoViewModel);


	[OperationContract]
	List<SexoViewModel> ConsultaSexos();

	[OperationContract]
	List<GradosViewModel> ConsultaGrados();


	// TODO: agregue aquí sus operaciones de servicio
}

