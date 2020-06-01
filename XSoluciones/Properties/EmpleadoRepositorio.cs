using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace XSoluciones.Properties
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        string connString = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;

        public object ID_Suplidor { get; set; }

        public OperationResult Create(Empleado empleado)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"INSERT INTO XSoluciones [(ID, Nombre, RNC, Representante, Direccion)] VALUES ('{empleado.Nombre}, {empleado.RNC}, {empleado.ID}, {empleado.Representante}, {empleado.Direccion}, {empleado.FechadeRegistro}')";
                    cmd.Connection = conn;

                    conn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return new OperationResult() { Result = true, Message = "Suplidor creado satisfactoriamente" };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult(false, $"Ha ocurrido un error {ex.Message}");
                    }

                }
            }
        }

        public OperationResult FindById(int ID_Suplidor)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT ID_Suplidor, Nombre, RNC, Representante, Direccion, FechadeRegistro FROM XSoluciones WHERE Borrado = 0 AND ID =  {ID_Suplidor}", conn))
                {

                    DataTable dt = new DataTable();

                    conn.Open();

                    try
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);

                        if (dt.Rows.Count > 0)
                        {
                            return new OperationResult() { Result = true, Data = dt };
                        }
                        else
                        {
                            return new OperationResult() { Result = false, Message = "No se encontraron registros." };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                    }

                }
            }
        }

        public OperationResult GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID_Suplidor, Nombre, RNC, Representante, Direccion, FechadeRegistro FROM XSoluciones WHERE XSoluciones = 0", conn))
                {

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    conn.Open();

                    try
                    {
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            return new OperationResult() { Result = true, Data = dt };
                        }
                        else
                        {
                            return new OperationResult() { Result = false, Message = $"No existe el suplidor {ID_Suplidor}" };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                    }

                }
            }
        }

        public OperationResult Update(Empleado empleado, int ID_Suplidor)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"UPDATE XSoluciones SET Nombre = '{empleado.ID}, {empleado.Nombre}, {empleado.RNC}, {empleado.Representante}, {empleado.FechadeRegistro}, {empleado.Direccion}' WHERE ID = {this.ID_Suplidor}";
                    cmd.Connection = conn;

                    conn.Open();

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult() { Result = false, Message = "No se encontró el suplidor." };
                        }
                        else
                        {
                            return new OperationResult() { Result = true, Message = "Suplidor actualizado satisfactoriamente." };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                    }
                }
            }
        }
        public OperationResult HardDelete(int ID_Suplidor)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"DELETE FROM XSoluciones WHERE ID = {ID_Suplidor}";
                    cmd.Connection = conn;

                    conn.Open();

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult() { Result = false, Message = "No se encontró el suplidor." };
                        }
                        else
                        {
                            return new OperationResult() { Result = true, Message = "Suplidor actualizado satisfactoriamente." };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                    }
                }
            }
        }
        public OperationResult SoftDelete(int ID_Suplidor)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"UPDATE XSoluciones SET Borrado = 1 WHERE ID = {ID_Suplidor}";
                    cmd.Connection = conn;

                    conn.Open();

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult() { Result = false, Message = "No se encontró el suplidor." };
                        }
                        else
                        {
                            return new OperationResult() { Result = true, Message = "Suplidor actualizado satisfactoriamente." };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                    }
                }
            }
        }
    }
}
