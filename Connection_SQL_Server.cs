using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Connection_With_SQL_Server
{
    public class Connection_SQL_Server
    {
        private string server;
        private string dataBase;
        private string userId;
        private string password;

        public Connection_SQL_Server(string s, string d, string u, string p)
        {
            this.server = s;
            this.dataBase = d;
            this.userId = u;
            this.password = p;
        }

        private string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(userId) || userId.Trim().Equals(string.Empty))
                {
                    return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=yes", server, dataBase);
                }
                else
                {
                    return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Pwd={3}", server, dataBase, userId, password);
                }
                
            }
        }

        public List<Dictionary<int, object>> ExecuteCommand(string statement, ref List<string> nombreColumnas)
        {

            List<Dictionary<int, object>> resultado = new List<Dictionary<int, object>>();
            nombreColumnas = new List<string>();

            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(statement);
                cm.CommandType = System.Data.CommandType.Text;
                cm.Connection = cn;

                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    if (nombreColumnas.Count == 0)
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            nombreColumnas.Add(dr.GetName(i));
                        }
                    }

                    Dictionary<int, object> fila = new Dictionary<int, object>();

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        fila.Add(i, dr[i]);
                    }

                    resultado.Add(fila);
                }
                dr.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        public bool ExistTable(string tableName)
        {
            List<string> columns = null;

            List<Dictionary<int, object>> datos = this.ExecuteCommand(string.Format("select 1 from sys.tables where name = '{0}'", tableName), ref columns);
            return datos.Count > 0;
        }

        public void DropTable(string tableName)
        {
            if (this.ExistTable(tableName))
            {
                SqlConnection cn = new SqlConnection(ConnectionString);
                try
                {
                    cn.Open();
                    SqlCommand cm = new SqlCommand(string.Format("drop table {0}", tableName));
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.Connection = cn;

                    cm.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        cn.Close();
                    }
                }

            }
        }

    
    }
}
