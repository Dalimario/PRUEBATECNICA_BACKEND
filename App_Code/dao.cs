using Boz.RestService.Model.Uitilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de dao
/// </summary>
public class dao
{   
        public static SqlConnection Con;
        public static void ConexionSQL()
        {
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();

                if (Con.State == ConnectionState.Closed) Con.Open();
            }
            catch (Exception)
            {
            
            }
        }
    
        public static UserModel Authenticate(LoginViewModel Request)
        {
            ConexionSQL();
            UserModel Response = new UserModel();
            using (Con)
            {
                using (var command = Con.CreateCommand())
                {
                    SqlDataReader reader;
                    command.CommandText = "[dbo].[ST_AUTHENTICATE_USER]";
                    command.CommandType = CommandType.StoredProcedure;

                    var pUser = new SqlParameter("@Username", SqlDbType.VarChar)
                    {
                        Value = Request.UserName,
                        Direction = ParameterDirection.Input
                    };

                    var pPassword = new SqlParameter("@UserPassword", SqlDbType.VarChar)
                    {
                        Value = Request.UserPassword,
                        Direction = ParameterDirection.Input
                    };

                    command.Parameters.Add(pUser);
                    command.Parameters.Add(pPassword);

                if (Con.State != ConnectionState.Open) { Con.Open(); }

                    reader = command.ExecuteReader();

                     if (reader.Read())
                    {
                        Response.Name = (reader.GetString(0));
                        Response.Apellido = (reader.GetString(1));
                    }

                    

                    if (Response.Name == null)
                    {
                        Response.Granted = false;
                    }
                    else 
                    {
                        Response.Granted = true;
                    }
                    
                    reader.Close();

            }
            }
            return Response;
        }


    public static List<ConsultaAlumnosViewModel> ConsultaAlumnos()
    {
        ConexionSQL();
        var list = new List<ConsultaAlumnosViewModel>();
        using (Con)
        {
            using (var command = Con.CreateCommand())
            {
                SqlDataReader reader;
                command.CommandText = "[dbo].[ST_SELECT_ALUMNOS]";
                command.CommandType = CommandType.StoredProcedure;

                if (Con.State != ConnectionState.Open) { Con.Open(); }
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var result = new ConsultaAlumnosViewModel
                        {
                            Nombre = ModelUtilities.GetString(reader["Nombre"]),
                            ApellidoPaterno = ModelUtilities.GetString(reader["ApellidoPaterno"]),
                            ApellidoMaterno = ModelUtilities.GetString(reader["ApellidoMaterno"]),
                            FechaNacimiento = ModelUtilities.GetDateTime(reader["FechaNacimiento"]),
                            Sexo = ModelUtilities.GetString(reader["Sexo"]),
                            Grado = ModelUtilities.GetString(reader["Grado"]),
                            Email = ModelUtilities.GetString(reader["Email"]),
                            Telefono = ModelUtilities.GetDouble(reader["Telefono"])
                        };
                        list.Add(result);
                    }

                }
        }
        return list;
    }



    }



    public static Response InsertarAlummnos(CrearAlumnoViewModel Alumno)
    {
        ConexionSQL();
        var response = new Response { ReturnCode = -1000 };
        using (Con)
        {
            using (var command = Con.CreateCommand())
            {
                command.CommandText = "[dbo].[ST_INSERT_ALUMNOS]";
                command.CommandType = CommandType.StoredProcedure;

                var v_Nombre = new SqlParameter("@Nombre", SqlDbType.VarChar)
                {
                    Value = ModelUtilities.SetStringDbNull(Alumno.Nombre),
                    Direction = ParameterDirection.Input
                };
                var v_ApellidoPaterno= new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar)
                {
                    Value = ModelUtilities.SetStringDbNull(Alumno.ApellidoPaterno),
                    Direction = ParameterDirection.Input
                };
                var v_ApellidoMaterno= new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar)
                {
                    Value = ModelUtilities.SetStringDbNull(Alumno.ApellidoMaterno),
                    Direction = ParameterDirection.Input
                };
                var v_FechaNacimiento = new SqlParameter("@FechaNacimiento", SqlDbType.VarChar)
                {
                    Value = ModelUtilities.SetStringDbNull(Alumno.FechaNacimiento.ToString().Substring(0,10)),
                    Direction = ParameterDirection.Input
                };
                var v_Sexo= new SqlParameter("@Sexo", SqlDbType.Int)
                {
                    Value = ModelUtilities.SetIntDbNull(Alumno.Sexo),
                    Direction = ParameterDirection.Input
                };
                var v_Grado = new SqlParameter("@Grado", SqlDbType.Int)
                {
                    Value = ModelUtilities.SetIntDbNull(Alumno.Grado),
                    Direction = ParameterDirection.Input
                };
                var v_Email = new SqlParameter("@Email", SqlDbType.VarChar)
                {
                    Value = ModelUtilities.SetStringDbNull(Alumno.Email.ToString()),
                    Direction = ParameterDirection.Input
                };
                var v_telefono = new SqlParameter("@telefono", SqlDbType.Int)
                {
                    Value = ModelUtilities.SetDoubleEmpty(Alumno.Telefono),
                    Direction = ParameterDirection.Input
                };



                var outReturnCode = new SqlParameter("@ReturnCode", SqlDbType.Int)
                {
                    Value = 0,
                    Direction = ParameterDirection.Output
                };
                var outReturnMessage = new SqlParameter("@returnMessage", SqlDbType.VarChar)
                {
                    Value = "",
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(v_Nombre);
                command.Parameters.Add(v_ApellidoPaterno);
                command.Parameters.Add(v_ApellidoMaterno);
                command.Parameters.Add(v_FechaNacimiento);
                command.Parameters.Add(v_Sexo);
                command.Parameters.Add(v_Grado);
                command.Parameters.Add(v_Email);
                command.Parameters.Add(v_telefono);
                command.Parameters.Add(outReturnCode);
                command.Parameters.Add(outReturnMessage);

                if (Con.State != ConnectionState.Open) { Con.Open(); }
                command.ExecuteNonQuery();

                response.ReturnCode = ModelUtilities.GetNotNullInt(outReturnCode.Value);
                response.ReturnString = ModelUtilities.GetString(outReturnMessage.Value);
            }
        }
        return response;
    }

    public static List<SexoViewModel> ConsultaSexo()
    {
        ConexionSQL();
        var list = new List<SexoViewModel>();
        using (Con)
        {
            using (var command = Con.CreateCommand())
            {
                SqlDataReader reader;
                command.CommandText = "[dbo].[ST_SELECT_SEXOS]";
                command.CommandType = CommandType.StoredProcedure;

                if (Con.State != ConnectionState.Open) { Con.Open(); }
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var result = new SexoViewModel
                        {
                            SexoID = ModelUtilities.GetNotNullInt(reader["SexoID"]),
                            Opcion = ModelUtilities.GetString(reader["Opcion"])
                        };
                        list.Add(result);
                    }

                }
            }
            return list;
        }

    }
    public static List<GradosViewModel> ConsultaGrados()
    {
        ConexionSQL();
        var list = new List<GradosViewModel>();
        using (Con)
        {
            using (var command = Con.CreateCommand())
            {
                SqlDataReader reader;
                command.CommandText = "[dbo].[ST_SELECT_GRADOS]";
                command.CommandType = CommandType.StoredProcedure;

                if (Con.State != ConnectionState.Open) { Con.Open(); }
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var result = new GradosViewModel
                        {
                            IDGrados = ModelUtilities.GetNotNullInt(reader["IDGrados"]),
                            Grados = ModelUtilities.GetString(reader["Grados"])
                        };
                        list.Add(result);
                    }

                }
            }
            return list;
        }

    }



}