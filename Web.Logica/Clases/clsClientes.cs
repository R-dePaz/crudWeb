using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Web.Logica.Clases
{
    public class clsClientes
    {
        string stConexion = "";
        SqlCommand sqlCommand = null;
        SqlConnection sqlConnection = null;
        SqlParameter sqlParameter = null;
        //SqlDataAdapter sqlDataAdapter = null;

        public clsClientes()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.stGetConexion();
        }

        public DataSet stConsultarClientes(long lnIdentificacion)
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("spConsultarClientes", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@nIdentificacion", lnIdentificacion));

                sqlCommand.ExecuteNonQuery();
                //sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //sqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;
            }
            catch (Exception ex) { throw ex; }
            finally { sqlConnection.Close(); }
        }

        public string stInsertarClientes(long lnIdentificacion,
                                            string stNombres,
                                            string stApellidos)
        {
            try
            {
                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("spInsertarClientes", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@nIdentificacion", lnIdentificacion));
                sqlCommand.Parameters.Add(new SqlParameter("@cNombres", stNombres));
                sqlCommand.Parameters.Add(new SqlParameter("@cApellidos", stApellidos));

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@cMensaje";
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 100;
                sqlParameter.Direction = ParameterDirection.Output;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.ExecuteNonQuery();

                return sqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { sqlConnection.Close(); }
        }

        public string stModificarClientes(long lnIdentificacion,
                                            string stNombres,
                                            string stApellidos)
        {
            try
            {
                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("spModificarClientes", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@nIdentificacion", lnIdentificacion));
                sqlCommand.Parameters.Add(new SqlParameter("@cNombres", stNombres));
                sqlCommand.Parameters.Add(new SqlParameter("@cApellidos", stApellidos));

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@cMensaje";
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 100;
                sqlParameter.Direction = ParameterDirection.Output;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.ExecuteNonQuery();

                return sqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { sqlConnection.Close(); }
        }

        public string stEliminarClientes(long lnIdentificacion)
        {
            try
            {
                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("spEliminarClientes", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@nIdentificacion", lnIdentificacion));

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@cMensaje";
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 100;
                sqlParameter.Direction = ParameterDirection.Output;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.ExecuteNonQuery();

                return sqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { sqlConnection.Close(); }
        }
    }
}
