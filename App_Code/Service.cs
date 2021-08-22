using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	dao Dao = new dao();

	public UserModel AuthenticateUser(LoginViewModel Accesos)
	{
		return dao.Authenticate(Accesos);
	}

	public List<ConsultaAlumnosViewModel> ConsultaAlumnos()
	{
		return dao.ConsultaAlumnos();
	}

	public Response InsertarAlummnos(CrearAlumnoViewModel crearAlumnoViewModel)
	{
		return dao.InsertarAlummnos(crearAlumnoViewModel);
	}

	public List<SexoViewModel> ConsultaSexos()
	{
		return dao.ConsultaSexo();
	}

	public List<GradosViewModel> ConsultaGrados()
	{
		return dao.ConsultaGrados();
	}




}
