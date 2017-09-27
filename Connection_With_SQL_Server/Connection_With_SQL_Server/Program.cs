using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_With_SQL_Server
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                Connection_SQL_Server db = new Connection_SQL_Server(".\\SQLExpress", "Ventas", "", "");
                if (db.TestConnection())
                {
                    Console.WriteLine("Conexión realizada");
                }
                else
                {
                    Console.WriteLine("Conexión fallida");
                }
                if (db.ExistTable("cantones"))
                {
                    List<string> columns = null;

                    List<Dictionary<int, object>> datos = db.ExecuteCommand("select id_cantón, nombre_cantón from cantones", ref columns);

                    foreach (var columna in columns)
                    {
                        Console.Write(columna);
                        Console.Write("\t");
                    }
                    Console.WriteLine("");

                    foreach (var fila in datos)
                    {
                        foreach (var campo in fila.Values)
                        {
                            Console.Write(campo.ToString());
                            Console.Write("\t");
                        }
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Tabla no existe");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

            try
            {
                Connection_SQL_Server db = new Connection_SQL_Server(".\\SQLExpress", "Ventas", "", "");

                List<Dictionary<int, object>> datos = db.ExecuteTablesDates();

                foreach (var fila in datos)
                {
                    foreach (var campo in fila.Values)
                    {
                        Console.Write(campo.ToString());
                        Console.Write("\t");
                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

            Console.ReadLine();
            return 0;
        }
    }
}
