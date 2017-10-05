﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
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

        public bool TestConnection()
        {
            SqlConnection cn;
            cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                if (cn != null)
                {
                    cn.Close();
                    return true;
                }
                else
                {
                    cn.Close();
                    return false;
                }
            }
            catch
            {
                cn.Close();
                return false;
            }
        }

        public List<Dictionary<int, object>> ExecuteCommand(string statement, ref List<string> nombreColumnas, bool mostrarMensajeError)
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
                if (mostrarMensajeError)
                {
                    DialogResult res = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
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

            List<Dictionary<int, object>> datos = this.ExecuteCommand(string.Format("select 1 from sys.tables where name = '{0}'", tableName), ref columns, true);
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

        public int GetQuantityAttribute(string tableName)
        {
            int numAttributes = 0;
            if (this.ExistTable(tableName))
            {
                SqlConnection cn = new SqlConnection(ConnectionString);
                try
                {
                    cn.Open();
                    SqlCommand cm = new SqlCommand(string.Format("select count(*) from sysobjects, syscolumns where sysobjects.id = syscolumns.id and sysobjects.name = '{0}'", tableName));
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.Connection = cn;
                    numAttributes = (int)(cm.ExecuteScalar());
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
            return numAttributes;
        }

        public List<Dictionary<int, object>> getTableDomain(string tableName)
        {

            List<Dictionary<int, object>> resultado = new List<Dictionary<int, object>>();

            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                //SqlCommand cm = new SqlCommand("SELECT o.Name as Table_Name, c.Name as Field_Name, t.Name as Data_Type FROM syscolumns c INNER JOIN sysobjects o ON o.id = c.id LEFT JOIN  systypes t on t.xtype = c.xtype WHERE o.type = 'U' ORDER BY o.Name, c.Name");
                SqlCommand cm = new SqlCommand(string.Format("select COLUMN_NAME,  DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION FROM INFORMATION_SCHEMA.COLUMNS AS c1 where c1.table_name = '{0}'", tableName));
                cm.CommandType = System.Data.CommandType.Text;
                cm.Connection = cn;

                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
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

        public List<Dictionary<int, object>> getTableNames()
        {
            List<Dictionary<int, object>> resultado = new List<Dictionary<int, object>>();

            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(string.Format("SELECT DISTINCT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS"));
                cm.CommandType = System.Data.CommandType.Text;
                cm.Connection = cn;

                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
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

        //Tablas con los atributos
        public List<Dictionary<int, object>> getTablesNamesAndAttributes()
        {
            List<Dictionary<int, object>> resultado = new List<Dictionary<int, object>>();

            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(string.Format("SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS ORDER BY TABLE_NAME, ORDINAL_POSITION"));
                cm.CommandType = System.Data.CommandType.Text;
                cm.Connection = cn;

                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
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
    }
}