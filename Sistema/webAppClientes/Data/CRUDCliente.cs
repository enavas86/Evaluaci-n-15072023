using webAppClientes.Models;
using System.Data.SqlClient;
using System.Data;

namespace webAppClientes.Data
{
    public class CRUDCliente
    {
        //Obtener todos los Clientes
        public List<ClienteModel> ListaCliente()
        {
            List<ClienteModel> _oList = new List<ClienteModel>();
            Conexion cn = new Conexion();

            using (SqlConnection _conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                _conexion.Open();
                SqlCommand _cmd = new SqlCommand("dbo.sp_ListClientes", _conexion);
                _cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader _dr = _cmd.ExecuteReader())
                {
                    while (_dr.Read())
                    {
                        _oList.Add(new ClienteModel()
                        {
                            Id = Convert.ToInt32(_dr["id"]),
                            PrimerNombre = Convert.ToString(_dr["primerNombre"]),
                            PrimerApellido = Convert.ToString(_dr["primeroApellido"]),
                            Edad = Convert.ToInt32(_dr["edad"]),
                            FechaCreacion = Convert.ToDateTime(_dr["fechaCreacion"])
                        });
                    }
                }
            }

            return _oList;
        }

        //Obtener un cliente
        public ClienteModel ObtenerCliente(int id)
        {
            ClienteModel _oCliente = new ClienteModel();
            Conexion cn = new Conexion();

            using (SqlConnection _conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                _conexion.Open();
                SqlCommand _cmd = new SqlCommand("dbo.sp_GetCliente", _conexion);
                _cmd.Parameters.AddWithValue("@p_id", id);
                _cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader _dr = _cmd.ExecuteReader())
                {
                    while (_dr.Read())
                    {
                        _oCliente.Id = Convert.ToInt32(_dr["id"]);
                        _oCliente.PrimerNombre = Convert.ToString(_dr["primerNombre"]);
                        _oCliente.PrimerApellido = Convert.ToString(_dr["primeroApellido"]);
                        _oCliente.Edad = Convert.ToInt32(_dr["edad"]);
                        _oCliente.FechaCreacion = Convert.ToDateTime(_dr["fechaCreacion"]);
                    }
                }
            }

            return _oCliente;
        }

        //Crear un nuevo cliente
        public bool GuardarCliente(ClienteModel oCliente)
        {
            bool _respuesta;
            try
            {
                Conexion cn = new Conexion();

                using (SqlConnection _conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    _conexion.Open();
                    SqlCommand _cmd = new SqlCommand("dbo.sp_InsertCliente", _conexion);
                    _cmd.Parameters.AddWithValue("@p_primerNombre", oCliente.PrimerNombre);
                    _cmd.Parameters.AddWithValue("@p_primerApellido", oCliente.PrimerApellido);
                    _cmd.Parameters.AddWithValue("@p_edad", oCliente.Edad);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.ExecuteNonQuery();
                }

                _respuesta = true;
            }
            catch (Exception e)
            {
                string _err = e.Message;
                _respuesta = false;
            }

            return _respuesta;
        }

        //Actualizar un cliente
        public bool ActualizarCliente(ClienteModel oCliente)
        {
            bool _respuesta;
            try
            {
                Conexion cn = new Conexion();

                using (SqlConnection _conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    _conexion.Open();
                    SqlCommand _cmd = new SqlCommand("dbo.sp_UpdateCliente", _conexion);
                    _cmd.Parameters.AddWithValue("@p_id", oCliente.Id);
                    _cmd.Parameters.AddWithValue("@p_primerNombre", oCliente.PrimerNombre);
                    _cmd.Parameters.AddWithValue("@p_primerApellido", oCliente.PrimerApellido);
                    _cmd.Parameters.AddWithValue("@p_edad", oCliente.Edad);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.ExecuteNonQuery();
                }

                _respuesta = true;
            }
            catch (Exception e)
            {
                string _error = e.Message;
                _respuesta = false;
            }

            return _respuesta;
        }

        //Eliminar un cliente
        public bool EliminarCliente(int id)
        {
            bool _respuesta;
            try
            {
                Conexion cn = new Conexion();

                using (SqlConnection _conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    _conexion.Open();
                    SqlCommand _cmd = new SqlCommand("dbo.sp_DeleteCliente", _conexion);
                    _cmd.Parameters.AddWithValue("@p_id", id);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.ExecuteNonQuery();
                }

                _respuesta = true;
            }
            catch (Exception e)
            {
                string _error = e.Message;
                _respuesta = false;
            }

            return _respuesta;
        }
    }
}
