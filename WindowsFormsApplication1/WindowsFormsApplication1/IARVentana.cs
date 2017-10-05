using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    public partial class IARVentana : Form
    {
        string nombreU = "";
        string passU = "";
        string nameBD = "";
        string nameS = "";
        bool _login = false;

        string table1;
        string table2;
        string tableR;
        string predicado;
        string operaciones;

        int tipoOperacion;

        List<Dictionary<int, object>> nombresTablas, tablasConAtributos;
        List<Dictionary<int, object>> tablasRenombradas;

        public IARVentana(int ptipoOperacion, string NU, string PU, string NB, string NS, List<Dictionary<int, object>> tablasAtributos)
        {

            InitializeComponent();

            nombreU = NU;
            passU = PU;
            nameBD = NB;
            nameS = NS;
            tipoOperacion = ptipoOperacion;
            tablasConAtributos = tablasAtributos;

            defineOperacion();

            salvarNombresTablas();
        }

        public IARVentana(int ptipoOperacion, string NU, string PU, string NB, string NS, List<Dictionary<int, object>> tablasAtributos, 
                            ref List<Dictionary<int, object>> tablasRenombre)
        {

            InitializeComponent();

            nombreU = NU;
            passU = PU;
            nameBD = NB;
            nameS = NS;
            tipoOperacion = ptipoOperacion;

            tablasConAtributos = tablasAtributos;
            tablasRenombradas = tablasRenombre;

            defineOperacion();

            salvarNombresTablas();
        }

        private void defineOperacion()
        {
            switch (tipoOperacion)
            {
                case 1:
                    label1.Text = "Selección";
                    BloqueaT2();
                    tOps.Enabled = false;
                    break;
                //*******************************************************
                case 2:
                    label1.Text = "Proyección Generalizada";
                    Contenido.Text = "Expresión";
                    BloqueaT2();
                    tOps.Enabled = false;
                    break;
                //*******************************************************
                case 3:
                    label1.Text = "Diferencia de Conjuntos";
                    BloqueaBox();
                    break;
                //*******************************************************
                case 4:
                    label1.Text = "Producto Cartesiano";
                    BloqueaBox();
                    break;
                //*******************************************************
                case 5:
                    label1.Text = "Intersección";
                    BloqueaBox();
                    break;
                //*******************************************************
                case 6:
                    label1.Text = "División";
                    BloqueaBox();
                    break;
                //*******************************************************
                case 7:
                    label1.Text = "Join";
                    tOps.Enabled = false;
                    break;
                //*******************************************************
                case 8:
                    label1.Text = "Natural Join";
                    BloqueaBox();
                    break;
                //*******************************************************
                case 9:
                    label1.Text = "Agregación";
                    BloqueaT2();
                    tContenido.Enabled = false;
                    break;
                //*******************************************************
                case 10:
                    label1.Text = "Agrupación";
                    Contenido.Text = "Atributos";
                    BloqueaT2();
                    break;
                //*******************************************************
                case 11:
                    label1.Text = "Unión";
                    BloqueaBox();
                    break;
                //*******************************************************
                case 12:
                    label1.Text = "Renombramiento";
                    Contenido.Text = "Atributos";
                    ltr.Text = "Nueva Tabla";
                    BloqueaT2();
                    tOps.Enabled = false;
                    break;
                //*******************************************************
                default:
                    break;
            }
        }

        //Salva los nombres de las tablas que estan en la BD desde el principio
        private void salvarNombresTablas()
        {
            Connection_SQL_Server temp = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);
            nombresTablas = temp.getTableNames();
        }

        private void IARVentana_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea cerrar la ventana?","Cerrar", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (res == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void BloqueaT2()
        {
            lt2.Enabled = false;
            lt2.Visible = false;
            tabla2.Enabled = false;
            tabla2.Visible = false;
        }

        private void BloqueaBox()
        {
            tContenido.Enabled = false;
            tOps.Enabled = false;
        }

        public bool Vacio(string evaluar)
        {
            evaluar = evaluar.Replace(" ", "");
            if (string.IsNullOrEmpty(evaluar))
                return true;

            return false;
        }

        private void asignacionTabla()
        {
            ExpresionAR.SelectionFont = new Font("Cambria", 11, FontStyle.Regular);
            ExpresionAR.SelectionColor = Color.Black;
            ExpresionAR.SelectedText = tableR + " ";

            ExpresionAR.SelectionFont = new Font("Symbol", 12, FontStyle.Bold);
            ExpresionAR.SelectionColor = Color.Blue;
            ExpresionAR.SelectedText = Simbolo.asignacion + " ";
        }

        private bool verificarAridadDominio()
        {
            Connection_SQL_Server temp = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);

            //aridad
            int aridad1, aridad2;
            aridad1 = temp.GetQuantityAttribute(tabla1.Text);
            aridad2 = temp.GetQuantityAttribute(tabla2.Text);
            if (aridad1 != aridad2)
            {
                DialogResult res = MessageBox.Show("Tablas con diferente aridad.\nLa tabla 1 tiene aridad: " + aridad1 + " y la tabla 2 tiene aridad: " + aridad2, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //dominio
            List<Dictionary<int, object>> dominioTabla1 = temp.getTableDomain(tabla1.Text);
            List<Dictionary<int, object>> dominioTabla2 = temp.getTableDomain(tabla2.Text);

            for (int i = 0; i < dominioTabla1.Count; i++)
            {
                var filaTabla1 = dominioTabla1.ElementAt(i);
                var filaTabla2 = dominioTabla2.ElementAt(i);

                string campoTabla1 = "", campoTabla2 = "";

                for (int j = 1; j < filaTabla1.Count; j++)
                {
                    campoTabla1 += filaTabla1.ElementAt(j).Value.ToString() + " ";
                    campoTabla2 += filaTabla2.ElementAt(j).Value.ToString() + " ";
                }

                if (!campoTabla1.Equals(campoTabla2))
                {
                    string atributo1 = filaTabla1.ElementAt(0).Value.ToString();
                    string atributo2 = filaTabla2.ElementAt(0).Value.ToString();
                    DialogResult res = MessageBox.Show("Dominios diferentes. \nEl atributo '" + atributo1 + "' tiene dominio '" + campoTabla1 +
                                                        "' y el atributo '" + atributo2 + "' tiene dominio '" + campoTabla2 + "'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private bool verificarDivision()
        {
            Connection_SQL_Server temp = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);

            List<Dictionary<int, object>> dominioTabla1 = temp.getTableDomain(tabla1.Text);
            List<Dictionary<int, object>> dominioTabla2 = temp.getTableDomain(tabla2.Text);

            for (int i = 0; i < dominioTabla2.Count; i++)
            {
                var filaTabla2 = dominioTabla2.ElementAt(i);
                bool esta = false;

                string campoTabla2 = "";

                for (int j = 0; j < filaTabla2.Count; j++)
                {
                    campoTabla2 += filaTabla2.ElementAt(j).Value.ToString() + " ";
                }

                for (int k = 0; k < dominioTabla1.Count; k++)
                {
                    var filaTabla1 = dominioTabla1.ElementAt(k);

                    string campoTabla1 = "";

                    for (int j = 0; j < filaTabla1.Count; j++)
                    {
                        campoTabla1 += filaTabla1.ElementAt(j).Value.ToString() + " ";
                    }
                    if (campoTabla2.Equals(campoTabla1))
                    {
                        esta = true;
                        break;
                    }
                }
                if (!esta)
                {
                    string atributo = filaTabla2.ElementAt(0).Value.ToString();
                    DialogResult res = MessageBox.Show("Dominios diferentes. \nEl atributo '"+atributo+"' de la tabla '"+tabla2.Text+
                                                        "' no está en la tabla '"+tabla1.Text+"'", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private bool verificarNaturalJoin()
        {
            Connection_SQL_Server temp = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);

            List<Dictionary<int, object>> dominioTabla1 = temp.getTableDomain(tabla1.Text);
            List<Dictionary<int, object>> dominioTabla2 = temp.getTableDomain(tabla2.Text);

            for (int i = 0; i < dominioTabla1.Count; i++)
            {
                var filaTabla1 = dominioTabla1.ElementAt(i);

                string campoTabla1 = "";

                for (int j = 0; j < filaTabla1.Count; j++)
                {
                    campoTabla1 += filaTabla1.ElementAt(j).Value.ToString() + " ";
                }

                for (int k = 0; k < dominioTabla2.Count; k++)
                {
                    var filaTabla2 = dominioTabla2.ElementAt(k);

                    string campoTabla2 = "";

                    for (int j = 0; j < filaTabla2.Count; j++)
                    {
                        campoTabla2 += filaTabla2.ElementAt(j).Value.ToString() + " ";
                    }
                    if (campoTabla1.Equals(campoTabla2))
                    {
                        return true;
                    }
                }
            }
            DialogResult res = MessageBox.Show("No hay atributos comunes.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool verificarPredicado()
        {
            
            string texto = tContenido.Text;
            if (!Vacio(texto))
            {
                bool valido = true;
                //CRUDS y modificadores
                if (texto.IndexOf("alter", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("drop", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("insert", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("update", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("delete", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("select", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("create", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                //premisos
                else if (texto.IndexOf("grant", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("revoke", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                //otros
                else if (texto.IndexOf("while", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("until", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }
                else if (texto.IndexOf("declare", StringComparison.OrdinalIgnoreCase) >= 0) { valido = false; }

                if (!valido)
                {
                    DialogResult res = MessageBox.Show("No se permite realizar más de una consulta.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //revisa el renombramiento
                if(tipoOperacion == 12)
                {
                    Connection_SQL_Server temp = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);
                    string nombreTabla = tabla1.Text;
                    int aridad = temp.GetQuantityAttribute(nombreTabla);

                    string[] nuevosAtributos;
                    nuevosAtributos = texto.Split(',', ' ');
                    nuevosAtributos = nuevosAtributos.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    
                    if(aridad != nuevosAtributos.Count())
                    {
                        DialogResult res = MessageBox.Show("No hay correspondencia en la cantidad de atributos.\n"
                            +"La tabla "+nombreTabla+" tiene "+aridad+" atributos y se están dando "+ nuevosAtributos.Count()+" atributos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private bool verificarTablaResultante()
        {
            string nombre = tablaR.Text;
            if (!Vacio(nombre) && tipoOperacion != 12) //con el renombramiento, esta caja de texto trabaja distinto   
            {
                foreach (var fila in nombresTablas)
                {
                    foreach (var campo in fila.Values)
                    {
                        if (nombre.Equals(campo.ToString()))
                        {
                            DialogResult res = MessageBox.Show("No se puede dejar el resultado en una tabla permanente de la base de datos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool validarCampos()
        {
            Connection_SQL_Server temp = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);

            int tipo = tipoOperacion;
            bool nombreTabla1 = true;
            bool nombreTabla2 = true;

            //Tablas existentes
            nombreTabla1 = temp.ExistTable(tabla1.Text);

            if (tipo == 11 || tipo == 3 || tipo == 4 || tipo == 5 || tipo == 6 || tipo == 7 || tipo == 8)
            {
                nombreTabla2 = temp.ExistTable(tabla2.Text);
            }

            if (nombreTabla1 == false)
            {
                DialogResult res = MessageBox.Show("No existe la tabla: " + tabla1.Text, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (nombreTabla2 == false)
            {
                DialogResult res = MessageBox.Show("No existe la tabla: " + tabla2.Text, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (nombreTabla1 == false || nombreTabla2 == false)
            {
                return false;
            }
            
            if(tipo == 11 || tipo == 3 || tipo == 5)
            {
                return verificarAridadDominio();
            }
            else if(tipo == 6)
            {
                //return verificarDivision(temp);
            }
            else if(tipo == 7)
            {
                //return verificarNaturalJoin(temp);
            }

            return true;
        }

        private void realizarConsultaSQL()
        {
            string expresion = ExpresionSQL.Text;

            Connection_SQL_Server prueba = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);

            List<string> columnas = null;

            List<Dictionary<int, object>> filas = prueba.ExecuteCommand(expresion, ref columnas, true);

            if(filas != null)
            {
                ResultGrid.Columns.Clear();
                ResultGrid.Rows.Clear();

                foreach (var columna in columnas)
                {
                    ResultGrid.Columns.Add(columna, columna);
                }

                int campos = columnas.Count;

                foreach (var fila in filas)
                {
                    int campo = 0;
                    string[] datos = new string[campos];
                    foreach (var espacio in fila.Values)
                    {
                        datos[campo] = espacio.ToString();
                        campo++;
                    }
                    ResultGrid.Rows.Add(datos);
                }
            }
        }

        private void realizarRenombramientoSQL()
        {
            string expresion = ExpresionSQL.Text;

            Connection_SQL_Server prueba = new Connection_SQL_Server(nameS, nameBD, nombreU, passU);

            List<string> columnas = null;

            string[] expresiones = expresion.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string palabra in expresiones)
            {
                if (!palabra.Equals("GO"))
                {
                    prueba.ExecuteCommand(palabra, ref columnas, true);
                }
            }
        }

        private void writeSQL(string operador)
        {
            ExpresionSQL.SelectionFont = new Font("Cambria", 11, FontStyle.Bold);
            ExpresionSQL.SelectionColor = Color.Blue;
            ExpresionSQL.SelectedText = operador;
        }

        private void writeRenameSQL(string operador)
        {
            ExpresionSQL.SelectionFont = new Font("Cambria", 11, FontStyle.Bold);
            ExpresionSQL.SelectionColor = Color.Brown;
            ExpresionSQL.SelectedText = operador;
        }

        private void writeStringSQL(string operador)
        {
            ExpresionSQL.SelectionFont = new Font("Cambria", 11, FontStyle.Bold);
            ExpresionSQL.SelectionColor = Color.Red;
            ExpresionSQL.SelectedText = "'"+operador+"'";
        }

        private void writeTextSQL(string texto)
        {
            ExpresionSQL.SelectionFont = new Font("Cambria", 11, FontStyle.Regular);
            ExpresionSQL.SelectionColor = Color.Black;
            ExpresionSQL.SelectedText = texto;
        }

        private void writeText(string texto)
        {
            ExpresionAR.SelectionFont = new Font("Cambria", 11, FontStyle.Regular);
            ExpresionAR.SelectionColor = Color.Black;
            ExpresionAR.SelectedText = texto;
        }

        private void writeTextL(string texto)
        {
            ExpresionAR.SelectionFont = new Font("Cambria", 8, FontStyle.Regular);
            ExpresionAR.SelectionColor = Color.Black;
            ExpresionAR.SelectedText = texto;
        }

        private void writeIAR(string operador)
        {
            int tO = tipoOperacion;
            
            if ((tO == 1) || (tO == 2) || (tO == 5) || (tO == 11))
            {
                ExpresionAR.SelectionFont = new Font("Symbol", 12, FontStyle.Bold);
            }
            else
            {
                ExpresionAR.SelectionFont = new Font("Calibri Math", 11, FontStyle.Regular);
            }
            ExpresionAR.SelectionColor = Color.Red;
            ExpresionAR.SelectedText = operador;
        }

        private void writeNewLine()
        {
            ExpresionSQL.SelectedText = Environment.NewLine;
        }

        //Verifica si a la tabla que se le quiere hacer un renombramiento
        // ya se le ha hecho un renombramiento anteriormente
        private int tablaYaRenombrada(string nombreTabla)
        {
            for (int i = 0; i < tablasRenombradas.Count; i++)
            {
                var cambios = tablasRenombradas.ElementAt(i);

                string nombreAnterior = cambios.ElementAt(1).Value.ToString();

                if (nombreAnterior.Equals(nombreTabla))
                {
                    return i;
                }
            }
            return -1;  //no hay índice donde haya correspondencia
        }

        private void agregarAtributosRenombramiento()
        {
            string[] nuevosAtributos;
            nuevosAtributos = predicado.Split(',', ' ');
            nuevosAtributos = nuevosAtributos.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            Dictionary<int, object> atributo = new Dictionary<int, object>();
            int indiceYaRenombrada = tablaYaRenombrada(tabla1.Text);

            if (indiceYaRenombrada != -1)       //si fue anteriormente renombrada
            {
                var cambios = tablasRenombradas.ElementAt(indiceYaRenombrada);
                string nombreOriginal = cambios.ElementAt(0).Value.ToString();

                tablasRenombradas.RemoveAt(indiceYaRenombrada);

                atributo.Add(0, nombreOriginal);
            }
            else
            {
                atributo.Add(0, tabla1.Text);
            }
            atributo.Add(1, tablaR.Text);

            for (int i = 0; i < nuevosAtributos.Count(); i++)
            {
                atributo.Add(i + 2, nuevosAtributos[i]);
            }

            tablasRenombradas.Add(atributo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool asignar = false;
            ExpresionAR.Text = "";
            ExpresionSQL.Text = " ";
            table1 = tabla1.Text;
            tableR = tablaR.Text;

            if (!validarCampos() || !verificarPredicado() || !verificarTablaResultante())
            {
                return;
            }

            switch (tipoOperacion)
            {
                //************************************************************************************************************************************
                case 1: //seleccion
                    predicado = tContenido.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(predicado))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeIAR(Simbolo.seleccion);
                            writeTextL(" " + predicado);
                            writeText(" (" + table1 + ")");

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);
                            writeNewLine();
                            writeSQL(Simbolo.whereSQL);
                            writeTextSQL(predicado);

                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el predicado de la expresión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 2: //proyeccion generalizada
                    predicado = tContenido.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(predicado))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeIAR(Simbolo.proyeccion);
                            writeTextL(" " + predicado);
                            writeText(" (" + table1 + ")");

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL(predicado);
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);

                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el predicado de la expresión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 3: //diferencia de conjuntos
                    table2 = tabla2.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(table2))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeText(table1 + " ");
                            writeIAR(Simbolo.diferencia);
                            writeText(" " + table2);

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);
                            writeNewLine();
                            writeSQL(Simbolo.exceptSQL);
                            writeNewLine();
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table2);

                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 4: //producto cartesiano
                    table2 = tabla2.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(table2))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeText(table1 + " ");
                            writeIAR(Simbolo.productoC);
                            writeText(" " + table2);

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1 + ", " + table2);
                            writeNewLine();

                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 5: //interseccion
                    table2 = tabla2.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(table2))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeText(table1 + " ");
                            writeIAR(Simbolo.interseccion);
                            writeText(" " + table2);

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();

                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);
                            writeNewLine();
                            writeSQL(Simbolo.intersectSQL);
                            writeNewLine();
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table2);
                            
                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 6: //division
                    table2 = tabla2.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(table2))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeText(table1 + " ");
                            writeIAR(Simbolo.division);
                            writeText(" " + table2);

                            verificarDivision();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 7: //join
                    table2 = tabla2.Text;
                    predicado = tContenido.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(table2))
                        {
                            if (!Vacio(predicado)) {
                                if (Vacio(tableR))
                                    asignar = false;
                                else
                                {
                                    asignar = true;
                                    asignacionTabla();
                                }
                                //EXPRESION ALGEBRA RELACIONAL
                                writeText(table1 + " ");
                                writeIAR(Simbolo.join);
                                writeTextL(" " + predicado);
                                writeText(" " + table2);

                                //EXPRESION SQL
                                writeSQL(Simbolo.selectSQL);
                                writeTextSQL("*");
                                writeNewLine();
                                if (asignar)
                                {
                                    writeSQL(Simbolo.intoSQL);
                                    writeTextSQL(tableR);
                                    writeNewLine();
                                }
                                writeSQL(Simbolo.fromSQL);
                                writeTextSQL(table1);
                                writeSQL(Simbolo.joinSQL);
                                writeTextSQL(table2);
                                writeNewLine();
                                writeSQL(Simbolo.onSQL);
                                writeTextSQL(predicado);

                                realizarConsultaSQL();
                            }
                            else
                            {
                                DialogResult res = MessageBox.Show("Debe escribir el predicado de la expresión a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 8: //natural join
                    table2 = tabla2.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(table2))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeText(table1 + " ");
                            writeIAR(Simbolo.join);
                            writeText(" " + table2);

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);
                            writeSQL(Simbolo.joinSQL);
                            writeTextSQL(table2);
                            writeNewLine();

                            verificarNaturalJoin();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 9: //agregacion
                    operaciones = tOps.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(operaciones))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeIAR(Simbolo.agregacion);
                            writeTextL(" " + operaciones);
                            writeText(" (" + table1 + ")");

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL(operaciones);
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);
                            writeNewLine();

                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 10: //agrupación
                    predicado = tContenido.Text;
                    operaciones = tOps.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(operaciones))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeTextL(predicado + " ");
                            writeIAR(Simbolo.agregacion);
                            writeTextL(" " + operaciones);
                            writeText(" (" + table1 + ")");

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL(operaciones);
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);
                            writeNewLine();
                            writeSQL(Simbolo.groupSQL);
                            writeTextSQL(predicado);

                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 11: //union
                    table2 = tabla2.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(table2))
                        {
                            if (Vacio(tableR))
                                asignar = false;
                            else
                            {
                                asignar = true;
                                asignacionTabla();
                            }
                            //EXPRESION ALGEBRA RELACIONAL
                            writeText(table1 + " ");
                            writeIAR(Simbolo.union);
                            writeText(" " + table2);

                            //EXPRESION SQL
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            if (asignar)
                            {
                                writeSQL(Simbolo.intoSQL);
                                writeTextSQL(tableR);
                                writeNewLine();
                            }
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table1);
                            writeNewLine();
                            writeSQL(Simbolo.unionSQL);
                            writeNewLine();
                            writeSQL(Simbolo.selectSQL);
                            writeTextSQL("*");
                            writeNewLine();
                            writeSQL(Simbolo.fromSQL);
                            writeTextSQL(table2);

                            realizarConsultaSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 2 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla 1 a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                case 12: //renombramiento
                    predicado = tContenido.Text;
                    if (!Vacio(table1))
                    {
                        if (!Vacio(predicado))
                        {
                            if (Vacio(tableR))
                            {
                                DialogResult res = MessageBox.Show("Debe escribir el nuevo nombre para la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                            //EXPRESION ALGEBRA RELACIONAL
                            writeIAR(Simbolo.renombramiento);
                            writeTextL(tableR + "(" + predicado + ")");
                            writeText(" (" + table1 + ")");

                            //EXPRESION SQL
                            //renombrar tabla
                            writeRenameSQL(Simbolo.renameSQL);
                            writeStringSQL(table1);
                            writeTextSQL(", ");
                            writeStringSQL(tableR);
                            writeNewLine();
                            writeSQL(Simbolo.goSQL);
                            writeNewLine();

                            //renombrar atributos
                            string[] nuevosAtributos;
                            nuevosAtributos = predicado.Split(',', ' ');
                            nuevosAtributos = nuevosAtributos.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                            int indiceYaRenombrada = tablaYaRenombrada(table1);

                            if (indiceYaRenombrada != -1)       //si fue anteriormente renombrada, tomo los atributos de la tabla renombrada
                            {
                                var campo = tablasRenombradas.ElementAt(indiceYaRenombrada);

                                for (int i = 2; i < campo.Count; i++)
                                {
                                    string atributo = campo.ElementAt(i).Value.ToString();
                                    writeRenameSQL(Simbolo.renameSQL);
                                    writeStringSQL(tableR + "." + atributo);
                                    writeTextSQL(", ");
                                    writeStringSQL(nuevosAtributos[i - 2]);
                                    writeTextSQL(", ");
                                    writeStringSQL("COLUMN");
                                    if(i != campo.Count - 1)
                                    {
                                        writeNewLine();
                                        writeSQL(Simbolo.goSQL);
                                        writeNewLine();
                                    }
                                }
                            }
                            else
                            {
                                int indiceOriginal=-1;
                                for (int i = 0; i < tablasConAtributos.Count(); i++)
                                {
                                    var campo = tablasConAtributos.ElementAt(i);
                                    string nombreTabla = campo.ElementAt(0).Value.ToString();

                                    if (nombreTabla.Equals(table1))
                                    {
                                        indiceOriginal = i;
                                        break;
                                    }
                                }
                                if(indiceOriginal == -1)
                                {
                                    DialogResult res = MessageBox.Show("Tabla no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                var campo1 = tablasConAtributos.ElementAt(indiceOriginal);

                                for (int i = 1; i < campo1.Count; i++)
                                {
                                    string atributo = campo1.ElementAt(i).Value.ToString();
                                    writeRenameSQL(Simbolo.renameSQL);
                                    writeStringSQL(tableR+"."+atributo);
                                    writeTextSQL(", ");
                                    writeStringSQL(nuevosAtributos[i - 1]);
                                    writeTextSQL(", ");
                                    writeStringSQL("COLUMN");
                                    if (i != campo1.Count - 1)
                                    {
                                        writeNewLine();
                                        writeSQL(Simbolo.goSQL);
                                        writeNewLine();
                                    }
                                }
                            }


                            agregarAtributosRenombramiento();

                            realizarRenombramientoSQL();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show("Debe escribir el predicado de la expresión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Debe escribir el nombre de la tabla a consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //************************************************************************************************************************************
                default:
                    break;
            }
        }

    }
}
