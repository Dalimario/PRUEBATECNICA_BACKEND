using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de AccesosModel
/// </summary>
public class LoginViewModel
{
    [Required(ErrorMessage = "El nombre de usuario es requerido")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida")]
    public string UserPassword { get; set; }

}