using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ConsultaAlumnosViewModel
/// </summary>
public class CrearAlumnoViewModel
{
            public string Nombre { get; set; }
            public string ApellidoPaterno { get; set; }

            public string ApellidoMaterno { get; set; }

            public DateTime? FechaNacimiento { get; set; }
            public int Sexo { get; set; }
            public int Grado { get; set; }

            public string Email { get; set; }

            public Double Telefono { get; set; }
    
}
